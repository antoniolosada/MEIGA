#include <Adafruit_MPU6050.h>
#include <BleMouse.h>
#include <EEPROM.h>

#define VEL_RATON 5
#define VEL_RATON_LENTO 1
#define MS_CLIC 3000
#define MS_LENTO_ACTIVAR 1000
#define MS_LENTO 2000

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


void setup() {
  // put your setup code here, to run once:
  bleMouse.begin();
  Serial.begin(115200);

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
}

void loop() 
{
    mpu_accel->getEvent(&accel);
      
    ax = accel.acceleration.x;
    ay = accel.acceleration.y;
    az = accel.acceleration.z;

    Serial.print(ax);
    Serial.print(",");
    Serial.print(ay);
    Serial.print(",");
    Serial.println(az);

    Adelante = 0;
    Atras = 0;
    Derecha = 0;
    Izquierda = 0;

    if (ax > 2.2)     Izquierda = 1;
    if (ay > 1.5)   Adelante = 1;
    if (ax < -1.2)  Derecha = 1;
    if (ay < -2.2)  Atras = 1;

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
            bleMouse.click(MOUSE_LEFT);
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
