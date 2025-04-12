#include <Adafruit_MPU6050.h>
#include <BleMouse.h>
#include <EEPROM.h>

#define VEL_RATON         5
#define VEL_RATON_LENTO   1
#define MS_CLIC           3000
#define MS_LENTO_ACTIVAR  1000
#define MS_LENTO          3000
#define DESACTIVAR_CLIC   1
#define EEPROM_SIZE       300
#define COD_INI           12348
#define CENTRO_X            700
#define CENTRO_Y            500
#define MAX_X               100
#define MAX_Y               100
#define TIEMPO_RESET        400
#define LIMITE_CALIBRAR       3
#define ESPERA_CALIBRACION  3000
#define INVERTIR            -1


BleMouse bleMouse;
Adafruit_MPU6050 mpu;
Adafruit_Sensor *mpu_temp, *mpu_accel, *mpu_gyro;
float ax = 0, ay = 0, az = 0;
int Pulsar = 0;
long IniMs = 0;
long IniMsLento = 0;
int Movimiento = 0;
int Velocidad = VEL_RATON;
sensors_event_t accel;

int Adelante = 0;
int Atras = 0;
int Derecha = 0;
int Izquierda = 0;

float jIzquierda = 2.2;
float jAdelante = 1.5;
float jDerecha = -1.2;
float jAtras = -2.2;



void setup() {
  int CodIni =0;

  // put your setup code here, to run once:
  bleMouse.begin();
  Serial.begin(115200);

  EEPROM.begin(EEPROM_SIZE);
  CodIni = EEPROM.readShort(0);
  if (CodIni == (int)COD_INI) LeerConfiguracion();

  if (!mpu.begin()) 
  {
    Serial.println("Failed to find MPU6050 chip");
    while (1) {
      digitalWrite(13, LOW);
      delay(500);
      digitalWrite(13, HIGH);
      delay(100);
    }
  }

  Serial.println("MPU6050 Found!");
  mpu_temp = mpu.getTemperatureSensor();
  mpu_temp->printSensorDetails();

  mpu_accel = mpu.getAccelerometerSensor();
  mpu_accel->printSensorDetails();

  mpu_gyro = mpu.getGyroSensor();
  mpu_gyro->printSensorDetails();

  delay(500);

  Calibrar();

}

void loop() 
{
    mpu_accel->getEvent(&accel);
      
    ax = accel.acceleration.x;
    ay = accel.acceleration.y*INVERTIR;
    az = accel.acceleration.z;

    Serial.print(ax);
    Serial.print(",");
    Serial.print(ay);
    Serial.print(",");
    Serial.print(az);
    Serial.print(",");
    Serial.print(jAdelante);
    Serial.print(",");
    Serial.print(jAtras);
    Serial.print(",");
    Serial.print(jDerecha);
    Serial.print(",");
    Serial.println(jIzquierda);

    Adelante = 0;
    Atras = 0;
    Derecha = 0;
    Izquierda = 0;

    if (ax > jIzquierda)     Izquierda = 1;
    if (ay > jAdelante*INVERTIR)   Adelante = 1;
    if (ax < jDerecha)  Derecha = 1;
    if (ay < jAtras*INVERTIR)  Atras = 1;

    if(bleMouse.isConnected()) 
    {
      if (Derecha)   MoverRaton(Velocidad, 0);
      if (Izquierda) MoverRaton(-Velocidad, 0);
      if (Atras)     MoverRaton(0, Velocidad);
      if (Adelante)  MoverRaton(0, -Velocidad);

      if ((Derecha+Izquierda+Adelante+Atras) == 0)
      {
        if (IniMs == 0)
        {
            IniMsLento = 0;
            IniMs = millis();
        }
        else if (millis() - IniMs > MS_CLIC)
        {
          if (Pulsar == 0)
          {
            Serial.println("clic");
            if (!DESACTIVAR_CLIC) bleMouse.click(MOUSE_LEFT);
            Pulsar = 1;
          }
        }

        //Si el tiempo de parada es suficiente activamos el movimiento lento
        if (millis() - IniMs > MS_LENTO_ACTIVAR)
            Velocidad = VEL_RATON_LENTO;
      }
      else
      {
        IniMs = 0;
        Pulsar = 0;
        if (Velocidad == VEL_RATON_LENTO)
        {
          if (IniMsLento == 0)
              IniMsLento = millis();
          else if (millis() - IniMsLento > MS_LENTO)
          {
              Velocidad = VEL_RATON;
              IniMsLento = 0;
          }
        }
          
      }
    }
    Movimiento = Derecha+Izquierda+Adelante+Atras;

    delay(10);
}

void MoverRaton(signed char x, signed char y)
 {
      if (bleMouse.isConnected())
        bleMouse.move(x,y);
 }

void LeerConfiguracion()
{
  int pos =0;
  int Codigo = EEPROM.readShort(pos);
  if (Codigo == COD_INI)
  {
      pos += sizeof(int);
      jIzquierda = EEPROM.readFloat(pos);
      pos += sizeof(float);
      jDerecha = EEPROM.readFloat(pos);
      pos += sizeof(float);
      jAdelante = EEPROM.readFloat(pos);
      pos += sizeof(float);
      jAtras = EEPROM.readFloat(pos);
  }
}

void EscribeConfiguracion()
{
  int pos = 0;
      EEPROM.writeShort(pos, (int)COD_INI);
      pos += sizeof(int);
      EEPROM.writeFloat(pos, jIzquierda);
      pos += sizeof(float);
      EEPROM.writeFloat(pos, jDerecha);
      pos += sizeof(float);
      EEPROM.writeFloat(pos, jAdelante);
      pos += sizeof(float);
      EEPROM.writeFloat(pos, jAtras);
      EEPROM.commit();
}

void Calibrar()
{
    delay(ESPERA_CALIBRACION*3);
    mpu_accel->getEvent(&accel);
    ay = accel.acceleration.y;

    Serial.println(ay);
    delay(2999);

    if (abs(ay) > LIMITE_CALIBRAR)
    {
      EstablecerCentroRaton(CENTRO_X, CENTRO_Y);
      Circunferencia(CENTRO_X, CENTRO_Y, 100, TIEMPO_RESET, 0, 2*PI,1);
      delay(ESPERA_CALIBRACION);
      mpu_accel->getEvent(&accel);
      ay = accel.acceleration.y;
      jAdelante = ay;
      Circunferencia(CENTRO_X, CENTRO_Y, 100, TIEMPO_RESET, 0, 2*PI,1);
      delay(ESPERA_CALIBRACION);
      mpu_accel->getEvent(&accel);
      ay = accel.acceleration.y;
      jAtras = ay;
      Circunferencia(CENTRO_X, CENTRO_Y, 100, TIEMPO_RESET, 0, 2*PI,1);
      delay(ESPERA_CALIBRACION);
      mpu_accel->getEvent(&accel);
      ax = accel.acceleration.x;
      jDerecha = ax;
      Circunferencia(CENTRO_X, CENTRO_Y, 100, TIEMPO_RESET, 0, 2*PI,1);
      delay(ESPERA_CALIBRACION);
      mpu_accel->getEvent(&accel);
      ax = accel.acceleration.x;
      jIzquierda = ax;

      EscribeConfiguracion();
    }

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
      if (bleMouse.isConnected())
        bleMouse.move(x-ant_x, y-ant_y);
    
    ant_x=x;
    ant_y=y;

    delay(10);	
  }
}

