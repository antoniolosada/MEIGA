#include <BleMouse.h>
#include <EEPROM.h>

#define VEL_RATON 5
#define MS_CLIC 3000
#define MS_LENTO 3000

float ax = 0, ay = 0, az = 0;
int Pulsar = 0;
long IniMs = 0;
long IniMsLento = 0;
int Movimiento = 0;

int Adelante = 0;
int Atras = 0;
int Derecha = 0;
int Izquierda = 0;


void setup() {
  // put your setup code here, to run once:
  //bleMouse.begin();
  Serial.begin(115200);

  delay(500);
}

void loop() 
{
    Adelante = analogRead(A0);
    Atras = analogRead(A1);
    Derecha = analogRead(A2);
    Izquierda = analogRead(A3);

    Serial.print(Adelante);
    Serial.print(",");
    Serial.print(Atras);
    Serial.print(",");
    Serial.print(Derecha);
    Serial.print(",");
    Serial.println(Izquierda);


/*
    if(bleMouse.isConnected()) 
    {
      if (Derecha)   MoverRaton(VEL_RATON, 0);
      if (Izquierda) MoverRaton(-VEL_RATON, 0);
      if (Atras)     MoverRaton(0, VEL_RATON);
      if (Adelante)  MoverRaton(0, -VEL_RATON);

      if ((Derecha+Izquierda+Adelante+Atras) == 0)
      {
        if (IniMs == 0)
            IniMs = millis();
        else if (millis() - IniMs > MS_CLIC)
        {
          if (Pulsar == 0)
          {
            Serial.println("clic");
            bleMouse.click(MOUSE_LEFT);
            Pulsar = 1;
          }
        }
      }
      else
      {
        IniMs = 0;
        Pulsar = 0;
      }
    }
    Movimiento = Derecha+Izquierda+Adelante+Atras;
*/
    delay(300);
}

void MoverRaton(signed char x, signed char y)
 {
      // if (bleMouse.isConnected())
      //   bleMouse.move(x,y);
 }
