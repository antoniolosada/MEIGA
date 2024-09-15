// Demo for getting individual unified sensor data from the MPU6050
#include <Adafruit_MPU6050.h>
#include <Kalman.h>
#include <BleMouse.h>
#include <Meiga.h>
#include <Comandos.h>
#include <EEPROM.h>

#define PI                3.1415
#define ESPERA_ACTIVACION 2000
#define MAX_ACCIONES      20
#define V_ALABEO          0
#define V_MEJILLA         1

#define MODO_ACEL_GIRO    0 //Utiliza el acelerómetro para el cabeceo y el giróscopo para guiñada
#define MODOD_ACEL        1 //Utiliza el acelerómetro para el cabeceo y para la guiñada

#define A_DESACTIVAR      0
#define A_ACTIVAR         1

#define FREQ_LOG_MS       100
#define FREQ_RATON_MS     10
#define C_RATON           0
#define MAX_CONTADORES_MS 10

#define TIEMPO_RESET        400

#define TIEMPO_SCROLL       150

#define CENTRO_X            700
#define CENTRO_Y            500
#define MAX_X               100
#define MAX_Y               100

#define EEPROM_SIZE         300

//Cfg *******************************************
int  PULSACION_CORTA_MS =       300;      
int PULSACION_MEDIA_MS =        1000;
int PULSACION_LARGA_MS =        5000;      
int PULSACION_ADC =             350;
int MULTIPLO_DELTA_X =          4;
int MULTIPLO_DELTA_Y =          5;
float ALABEO_SCROLL_MIN_NEG =   -2.5;
float ALABEO_SCROLL_MAX_NEG =   -1.0; 
float ALABEO_SCROLL_MIN_POS =   1; 
float ALABEO_SCROLL_MAX_POS =   2.5;
float CORRECION_ALABEO_DER =      1.2;
int TIEMPO_MIN_SCROLL =         200;
int CFG_MODO =                  0;
int  DIRECCION =                1;
int  PULSACION =                1;
int  SCROLL =                   1;
int  MOVIMIENTO =               1;
int  CLIC_MEDIO =               1;
int  CLIC_DER =                 1;
int  CLIC_IZQ =                 1;
int  ACCIONES =                 1;

//***********************************************

BleMouse bleMouse;

Adafruit_MPU6050 mpu;
Adafruit_Sensor *mpu_temp, *mpu_accel, *mpu_gyro;

int DEBUG = 0;
int x, y;
int max_acel_x;
int max_Acel_y;
long tiempo_prev;
float dt;
int ax, ay, az;
float gx, gy, gz;
float egx = 0.03, egy = 0.02, egz = -0.02;

float girosc_ang_x, girosc_ang_y, girosc_ang_z;
float girosc_ang_x_prev, girosc_ang_y_prev, girosc_ang_z_prev;

float ang_x, ang_y, ang_z;
float ang_x_prev, ang_y_prev, ang_z_prev;

Kalman myFilterX(0.125, 12, 1023,0);
Kalman myFilterY(0.125, 12, 1023,0); 
Kalman myFilterAlabeo(0.125, 12, 1023,0); 

struct ContadorMs
{
  long MaxMs;
  long Ms;
};

ContadorMs ContadoresMs[MAX_CONTADORES_MS];

float posX, posY, filtroX, filtroY;

  //  /* Get a new normalized sensor event */
  sensors_event_t accel;
  sensors_event_t gyro;
  sensors_event_t temp;


PosAccion Acciones[MAX_ACCIONES];
int NumAcciones = 0;
int ActivarAccion;

float difcentroRatonX, difcentroRatonY; // Diferencias para estabilizar la posición central a 0
float maxRatonX, maxRatonY; //Máximos valores recuperados por el sensor IMU
float minRatonX, minRatonY; //Mínimos valores recuperados por el sensor IMU

int centroPantallaRatonX, centroPantallaRatonY;
int PantallaRatonX= 900, PantallaRatonY = 800;
float deltaX = 0, deltaY = 0, deltaMs = 0;
float AnteriorPosX = 0, AnteriorPosY = 0, AnteriorMs = 0;
float MultiploX = MULTIPLO_DELTA_X, MultiploY = MULTIPLO_DELTA_Y;
long MsPulsacion;
float Mejilla;
bool BotonDerPulsado = false;
int MejillaIni =0;

float alabeoDerecha;
float alabeoIzquierda;
float difAlabeo = 0;

long TiempoAlabeo = 0;
long TiempoScroll = 0;
float Alabeo = 0;
float filtroAlabeo = 0;

float PosX = 0, PosY = 0, PosRatonX = 0, PosRatonY = 0;
long MsIni = 0;
bool calibracion = false;

bool MeigaActivo = false;
int iPosCad = 0;

//*******************************************  SETUP  *****************************************
void setup(void) 
{
  int CodIni =0;
  DEBUG = 1;
  EEPROM.begin(EEPROM_SIZE);

  CodIni = EEPROM.read(0);
  if (CodIni == (int)COD_INI) LeerConfiguracion();

  DefinirAcciones();
  Serial.begin(115200);
  while (!Serial)
    delay(10); // will pause Zero, Leonardo, etc until serial console opens

  Serial.println("Adafruit MPU6050 test!");

  if (!mpu.begin()) 
  {
    Serial.println("Failed to find MPU6050 chip");
    while (1) {
      delay(10);
    }
  }

  Serial.println("MPU6050 Found!");
  mpu_temp = mpu.getTemperatureSensor();
  mpu_temp->printSensorDetails();

  mpu_accel = mpu.getAccelerometerSensor();
  mpu_accel->printSensorDetails();

  mpu_gyro = mpu.getGyroSensor();
  mpu_gyro->printSensorDetails();

  MsIni = millis();

  MeigaActivo = false;

  bleMouse.begin();
}

//************************************************  LOOP  ***************************************************************
void loop() 
{
  if (LeerCadena(&iPosCad, Cadena) == LECTURA_FIN)
  {
    ProcesarCadena(Cadena);
    Cadena[0] = 0;
  }

  mpu_temp->getEvent(&temp);
  mpu_accel->getEvent(&accel);
  mpu_gyro->getEvent(&gyro);

  // Leer las velocidades angulares 
  gx = gyro.gyro.x + egx;
  gy = gyro.gyro.y + egy;
  gz = gyro.gyro.z + egz;

  ax = accel.acceleration.x;
  ay = accel.acceleration.y;
  az = accel.acceleration.z;

  posX = accel.acceleration.y;
  posY = accel.acceleration.z;

  dt = millis() - tiempo_prev;
  tiempo_prev = millis();

  updateGiro();
  updateFiltered();

  filtroX = myFilterX.getFilteredValue(posX);
  filtroY = myFilterY.getFilteredValue(posY);

  PosX = (girosc_ang_x)*100;
  PosY = (girosc_ang_z)*100;
  Alabeo = accel.acceleration.z-difAlabeo;
  Mejilla = analogRead(A0);

  filtroAlabeo = myFilterAlabeo.getFilteredValue(Alabeo);

  delay(1);

  if (ACCIONES == 1)
  {
    ActivarAccion = ControlAcciones();

    switch(ActivarAccion)
    {
      case A_DESACTIVAR:
      case A_ACTIVAR:
          ActivarMeiga();
          break;
    }
  }
  if (MeigaActivo)
  {
    if (FinContador(C_RATON)) ControlRaton();
  }

  if (LOG_SALIDA) SalidaPosicion();    
  if (!calibracion) ActivarMeiga();

  LOG_FIN();
}

//************************************************  END LOOP  ******************************************************************************************************************************

void ControlRaton()
{
  unsigned long startTime;

  deltaX = AnteriorPosX - PosX;
  deltaY = AnteriorPosY - PosY;

  deltaMs = millis() - AnteriorMs;

  AnteriorPosX = PosX;
  AnteriorPosY = PosY;
  AnteriorMs = millis();

  int MovX = deltaX/deltaMs*MultiploX;
  int MovY = deltaY/deltaMs*MultiploY;

  if(bleMouse.isConnected()) 
  {
    MoverRaton(MovX*DIRECCION, -MovY);

    if (AlabeoActivo())
    {
      if (TiempoAlabeo)
      {
        if (millis() - TiempoAlabeo > TIEMPO_MIN_SCROLL)
        {
          if (millis() - TiempoScroll > TIEMPO_SCROLL)
          {
            if (filtroAlabeo > 0)
              ScrollRaton(1);
            else
              ScrollRaton(-1);
            TiempoScroll = millis();  
          } else if (TiempoScroll == 0) TiempoScroll = millis();  
        }
      }
      else TiempoAlabeo = millis();
    }
    else 
    {
      TiempoAlabeo = 0;
      TiempoScroll = 0;
    }


    long Tiempo = millis() - MsPulsacion;
    if (abs(MejillaIni - Mejilla) > PULSACION_ADC)
    {
      if (MsPulsacion == 0)
        MsPulsacion = millis();
      else if (Tiempo > PULSACION_LARGA_MS)
      {
        PulsarRaton(MOUSE_LEFT);
        BotonDerPulsado = true;
      }
    }
    else 
    {
      if (BotonDerPulsado)
      {
        LiberarRaton(MOUSE_LEFT);
        BotonDerPulsado = false;
      }
      else if (MsPulsacion)
      {
        if (Tiempo < PULSACION_CORTA_MS) {
          ClicRaton(MOUSE_LEFT);
        }
        else if (Tiempo < PULSACION_MEDIA_MS){
          ClicRaton(MOUSE_MIDDLE);
        }
        else {
          ClicRaton(MOUSE_RIGHT);
        }
      }
      MsPulsacion = 0;
    }
  }
}

void ActivarMeiga()
{
  girosc_ang_x = 0;
  girosc_ang_y = 0;
  PosRatonX = 0;
  PosRatonY = 0;
  Calibrar();
  AnteriorPosX = PosX;
  AnteriorPosY = PosY;
  AnteriorMs = millis();
  MeigaActivo = true;

}

void DesactivarMeiga()
{
  MeigaActivo = false;
  Serial.println("MEIGA desactivado");
  delay(ESPERA_ACTIVACION);
  IniciarContadorMs(C_RATON, FREQ_RATON_MS);
}

int ControlAcciones()
{
  float v;
  for (int i=0; i< NumAcciones; i++)
  {

    switch(Acciones[i].Variable)
    {
      case V_ALABEO:
        v = filtroAlabeo;
        break;
      case V_MEJILLA:
        v = (float)Mejilla;
        break;
    }

    if ((v > Acciones[i].Min) && (v < Acciones[i].Max))
    {
      if (Acciones[i].MsActivacion == 0) Acciones[i].MsActivacion = millis();
    }
    else
    {
      long TiempoMsActivacion = (millis() - Acciones[i].MsActivacion);
        if ( Acciones[i].MsActivacion && (TiempoMsActivacion > Acciones[i].TiempoMinSeg) && (TiempoMsActivacion < Acciones[i].TiempoMaxSeg) )
        {
          Acciones[i].MsActivacion = 0;
          return Acciones[i].Codigo;
        }
        Acciones[i].MsActivacion = 0;
    }
  }
  return -1;
}

void Calibrar()
{
  EstablecerCentroRaton(CENTRO_X, CENTRO_Y);
  Circunferencia(CENTRO_X, CENTRO_Y, 100, TIEMPO_RESET, 0, 2*PI,1);
  MejillaIni = analogRead(A0);
  mpu_accel->getEvent(&accel);
  Alabeo = accel.acceleration.z;
  difAlabeo = Alabeo;

  calibracion = true;
}

void SalidaPosicion()
{
  Serial.print("\t\Pos X: ");
  Serial.printf("%7.2f:", PosX);
  Serial.printf(", %7.2f", PosRatonX);
  Serial.print(" Y: ");
  Serial.printf("%7.2f:", PosY);
  Serial.printf(", %7.2f", PosRatonY);
  Serial.printf(", mejilla: %d:", analogRead(A0)-MejillaIni);
  Serial.printf(", FiltroAlabeo: %7.2f:", filtroAlabeo);
  Serial.println("");
}

void Salida()
{
     /* Display the results (acceleration is measured in m/s^2) */
  Serial.print("\t\tAccel X: ");
  Serial.printf("%7.2f", accel.acceleration.x);
  Serial.print(" Y: ");
  Serial.printf("%7.2f",accel.acceleration.y);
  Serial.print(" Z: ");
  Serial.printf("%7.2f", accel.acceleration.z);

  /* Display the results (rotation is measured in rad/s) */
  Serial.print("\t\tGyro X: ");
  Serial.printf("%7.2f", gx);
  Serial.print(" Y: ");
  Serial.printf("%7.2f", gy);
  Serial.print(" Z: ");
  Serial.printf("%7.2f", gz);

  Serial.print("\tRot_Gyro en X:  ");
  Serial.printf("%7.2f", girosc_ang_x);
  Serial.print(F(" Y: "));
  Serial.printf("%7.2f", girosc_ang_y);
  Serial.print(F(" Z: "));
  Serial.printf("%7.2f", girosc_ang_z);

  Serial.print("\tFiltro en X:  ");
  Serial.printf("%7.2f", ang_x); 
  Serial.print(" Y: ");
  Serial.printf("%7.2f", ang_y);  

  Serial.print("\tKalman en X:  ");
  Serial.printf("%7.2f", filtroX); 
  Serial.print(" Y: ");
  Serial.printf("%7.2f", filtroY);  

  Serial.println("");
}

void updateGiro()
{

  girosc_ang_x = (gx *180/3.14)*dt / 1000.0 + girosc_ang_x_prev;
  girosc_ang_y = (gy *180/3.14)*dt / 1000.0 + girosc_ang_y_prev;
  girosc_ang_z = (gz *180/3.14)*dt / 1000.0 + girosc_ang_z_prev;

  girosc_ang_x_prev = girosc_ang_x;
  girosc_ang_y_prev = girosc_ang_y;
  girosc_ang_z_prev = girosc_ang_z;
}

void updateFiltered()
{
  dt = dt / 1000.0;

  //Calcular los ángulos con acelerometro
  float accel_ang_x = atan(ay / sqrt(pow(ax, 2) + pow(az, 2)))*(180.0 / 3.14);
  float accel_ang_y = atan(-ax / sqrt(pow(ay, 2) + pow(az, 2)))*(180.0 / 3.14);

  //Calcular angulo de rotación con giroscopio y filtro complementario
  ang_x = 0.98*(ang_x_prev + (gx *180/3.14)*dt) + 0.02*accel_ang_x;
  ang_y = 0.98*(ang_y_prev + (gy *180/3.14)*dt) + 0.02*accel_ang_y;

  ang_x_prev = ang_x;
  ang_y_prev = ang_y;
}

void EstablecerCentroRaton(int cx, int cy)
{
  if(bleMouse.isConnected()) 
  {
      for (int i=0; i<MAX_X; i++)
      {
        bleMouse.move(0,-30);
        delay(1);
      }

      for (int i=0; i<MAX_Y; i++)
      {
        bleMouse.move(-30,0);
        delay(1);
      }

      for (int i=0; i<10; i++)
      {
        bleMouse.move(20,20);
        delay(1);
      }
  }
}

void DefinirAcciones()
{
  PosAccion Accion;
  Accion = {A_DESACTIVAR, V_ALABEO, 3, 20, 2000, 5000, 0};
  Acciones[0] = Accion;
  Accion = {A_ACTIVAR, V_ALABEO, -20, -3, 2000, 5000, 0};
  Acciones[1] = Accion;
  NumAcciones = 2;
}

bool Posicion(float n, PosAccion pa)
{
  if ((n > pa.Min) && (n < pa.Max))
    return true;
  else
    return false;
}

//---------------------------------  LOG  -----------------------------------------------------------------------


void LOG(String s1, String s2, bool rc)
{
    if (LOG_SALIDA) {
      MsIni= millis();
      Serial.print(s1);
      Serial.print(s2);
      Serial.println(" ");
      if (rc) Serial.print("");
    }
}

void LOG(String s1, float s2, bool rc)
{
    if (LOG_SALIDA) {
      Serial.print(s1);
      Serial.print(s2);
      Serial.print(" ");
      if (rc) Serial.println("");
    }
}

void LOG(String s1, long s2, bool rc)
{
    if (LOG_SALIDA) {
      Serial.print(s1);
      Serial.print(s2);
      Serial.print(" ");
      if (rc) Serial.println("");
    }
}

void LOG(String s1, int s2, bool rc)
{
    if (LOG_SALIDA) {
      Serial.print(s1);
      Serial.print(s2);
      Serial.print(" ");
      if (rc) Serial.println("");
    }
}

bool LOG_SALIDA()
{
  return (millis() - MsIni > FREQ_LOG_MS);
}

void LOG_FIN()
{
    if (LOG_SALIDA) MsIni= millis();
}

void LOG_controlacciones()
{
    // LOG("i=", i, false);
    // LOG("min=", Acciones[i].Min, false);
    // LOG("max=", Acciones[i].Max, false);
    // LOG("ms=", Acciones[i].MsActivacion, false);
    // LOG("v=", v, false);

}

void Configuracion()
{
  //Posicion Centro
  //Posicion Arriba
  //Posicion Abajo
  //Posicion Derecha
  //Posicion Izquierda
  //Fin pantalla arriba
  //Fin pantalla abajo
  //Fin pantalla derecha
  //Fin pantalla izquierda
}

void IniciarContadorMs(int c, long ms)
{
  ContadoresMs[c].Ms = millis();
  ContadoresMs[c].MaxMs = ms;
}

bool FinContador(int c)
{
  if (millis()-ContadoresMs[c].MaxMs > ContadoresMs[c].Ms)
  {
    ContadoresMs[c].Ms = millis();
    return true;
  }
  return false;
}

void Circunferencia(int cx, int cy, int r, int ms, float ang_ini, float ang_fin, int dir)
{
  int x, ant_x=cx;
  int y, ant_y=cy;
  float ang;

  for (int i=0; i < ms; i++)
  {
    ang = ang_ini+abs(ang_fin-ang_ini)/ms*i*dir;
    x = cx+r*cos(ang);
    y = cy+r*sin(ang);

    if ((x != ant_x) || (y != ant_y))
      bleMouse.move(x-ant_x, y-ant_y);
    
    ant_x=x;
    ant_y=y;

    delay(10);	
  }
}

int recta (int p1x, int p1y, int p2x, int p2y, int ms, int dir)
{
  int x;
  int y;

  for (int i=0; i < ms; i++)
  {
    x= p1x+abs(p2x-p1x)/ms*i*dir;
    y= p1y+abs(p2y-p1y)/ms*i*dir;
  }
}

bool AlabeoActivo()
{
  if (filtroAlabeo < 0)
  {
    if ((filtroAlabeo < ALABEO_SCROLL_MAX_NEG) && (filtroAlabeo > ALABEO_SCROLL_MIN_NEG))
      return true;
  }
  else
  {
    if ((filtroAlabeo > ALABEO_SCROLL_MIN_POS) && (filtroAlabeo < ALABEO_SCROLL_MAX_POS))
      return true;
  }
  return false;
}

void LeerConfiguracion()
{
  delay(ESPERA_CFG);
  int pos =0;
  int Codigo = EEPROM.readShort(pos);
  if (Codigo == COD_INI)
  {
      pos += sizeof(int);
      MULTIPLO_DELTA_X = EEPROM.readShort(pos);
      pos += sizeof(int);
      MULTIPLO_DELTA_Y = EEPROM.readShort(pos);
      pos += sizeof(int);
      PULSACION_CORTA_MS = EEPROM.readShort(pos);
      pos += sizeof(int);
      PULSACION_MEDIA_MS = EEPROM.readShort(pos);
      pos += sizeof(int);
      PULSACION_LARGA_MS = EEPROM.readShort(pos);
      pos += sizeof(int);
      PULSACION_ADC = EEPROM.readShort(pos);
      pos += sizeof(int);
      ALABEO_SCROLL_MIN_NEG = EEPROM.readFloat(pos);
      pos += sizeof(float);
      ALABEO_SCROLL_MAX_NEG = EEPROM.readFloat(pos);
      pos += sizeof(float);
      ALABEO_SCROLL_MIN_POS = EEPROM.readFloat(pos);
      pos += sizeof(float);
      ALABEO_SCROLL_MAX_POS = EEPROM.readFloat(pos);
      pos += sizeof(float);
      CORRECION_ALABEO_DER = EEPROM.readFloat(pos);
      pos += sizeof(float);
      TIEMPO_MIN_SCROLL = EEPROM.readShort(pos);
      pos += sizeof(int);
      DIRECCION = EEPROM.readShort(pos);
      pos += sizeof(int);
      PULSACION = EEPROM.readShort(pos);
      pos += sizeof(int);
      SCROLL = EEPROM.readShort(pos);
      pos += sizeof(int);
      MOVIMIENTO = EEPROM.readShort(pos);
      pos += sizeof(int);
      CLIC_DER = EEPROM.readShort(pos);
      pos += sizeof(int);
      CLIC_IZQ = EEPROM.readShort(pos);
      pos += sizeof(int);
      CLIC_MEDIO = EEPROM.readShort(pos);
      pos += sizeof(int);
      ACCIONES = EEPROM.readShort(pos);
      pos += sizeof(int);
      CFG_MODO = EEPROM.readShort(pos);

      LecturaCfg();
 }
 else Serial.println("Cfg no guardada.");
}

void LecturaCfg()
{
Serial.print("@#C:");
Serial.print(MULTIPLO_DELTA_X);
Serial.print(",");
Serial.print(MULTIPLO_DELTA_Y);
Serial.print(",");
Serial.print(PULSACION_CORTA_MS);
Serial.print(",");
Serial.print(PULSACION_MEDIA_MS);
Serial.print(",");
Serial.print(PULSACION_LARGA_MS);
Serial.print(",");
Serial.print(PULSACION_ADC);
Serial.print(",");
Serial.print(ALABEO_SCROLL_MIN_NEG);
Serial.print(",");
Serial.print(ALABEO_SCROLL_MAX_NEG);
Serial.print(",");
Serial.print(ALABEO_SCROLL_MIN_POS);
Serial.print(",");
Serial.print(ALABEO_SCROLL_MAX_POS);
Serial.print(",");
Serial.print(CORRECION_ALABEO_DER);
Serial.print(",");
Serial.print(TIEMPO_MIN_SCROLL);
Serial.print(",");
Serial.print(DIRECCION);
Serial.print(",");
Serial.print(PULSACION);
Serial.print(",");
Serial.print(SCROLL);
Serial.print(",");
Serial.print(MOVIMIENTO);
Serial.print(",");
Serial.print(CLIC_DER);
Serial.print(",");
Serial.print(CLIC_IZQ);
Serial.print(",");
Serial.print(CLIC_MEDIO);
Serial.print(",");
Serial.print(ACCIONES);
Serial.print(",");
Serial.print(CFG_MODO);
Serial.print(",");
Serial.println("END;.");
}

void MoverRaton(signed char x, signed char y)
 {
      if (MOVIMIENTO == 1) bleMouse.move(x,y);
 }
 void ScrollRaton(signed char s) 
 {
      if (SCROLL) bleMouse.move(0,0,s);
 }

 void PulsarRaton(uint8_t boton)
 {
        if (PULSACION) bleMouse.press(boton);
 }
 void LiberarRaton(uint8_t boton)
 {
        if (PULSACION) bleMouse.release(boton);
 }
 void ClicRaton(uint8_t boton)
 {
    switch(boton)
    {
      case MOUSE_MIDDLE:
      {
        if (CLIC_MEDIO) bleMouse.click(boton);
        break;
      }
      case MOUSE_LEFT:
      {
        if (CLIC_IZQ) bleMouse.click(boton);
        break;
      }
      case MOUSE_RIGHT:
      {
        if (CLIC_DER) bleMouse.click(boton);
        break;
      }
    }
    
 }

