#define EXTERN_FILE
#include <Comandos.h>
#include <Meiga.h>

char Cadena[MAX_LON_CADENA];

int MultiplicadorX;
int MultiplicadorY;
int PulsacionCorta;
int PulsacionMEdia;
int PulsacionLarga;
int PulsacionADC;
float AlabeoMinNeg;
float AlabeoMaxNeg;
float AlabeoMinPos;
float AlabeoMaxPos;
float CorrecionAlabeoDer;
int   TiempoMinScroll;
int   Direccion;
int   Pulsacion;
int   Scroll;
int   Movimiento;
int   ClicDer;
int   ClicIzq;
int   ClicMedio;
int   ModoOperacion;
int   EjecAcciones;


void ProcesarCadena(char *Cadena)
{
  char cCar;
  int i;
  int iPosFin;
  int iNumServo;
  int iNumSensor;
  int iValor;
  int iModo;
  long CRC;
  int p;
  
  Serial.println(Cadena);
  cCar = Cadena[0];
  if (cCar == '@')
  {
    CRC = RecValor(Cadena, 1, ':', &iPosFin);
    p = iPosFin;
    if (!ComprobarCRC(CRC, Cadena+p++)) return;
  
    cCar = Cadena[p++];
    switch (cCar)
    {
	  case 'R':
      {
        ESP.restart();
      }
	  case 'G':
      { 
        delay(ESPERA_CFG);

        MultiplicadorX = RecValor(Cadena, p, ',', &iPosFin);
        MultiplicadorY = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        PulsacionCorta = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        PulsacionMEdia = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        PulsacionLarga = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        PulsacionADC = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        AlabeoMinNeg = RecFloat(Cadena, iPosFin + 1, ',', &iPosFin);
        AlabeoMaxNeg = RecFloat(Cadena, iPosFin + 1, ',', &iPosFin);
        AlabeoMinPos = RecFloat(Cadena, iPosFin + 1, ',', &iPosFin);
        AlabeoMaxPos = RecFloat(Cadena, iPosFin + 1, ',', &iPosFin);
        CorrecionAlabeoDer = RecFloat(Cadena, iPosFin + 1, ',', &iPosFin);
        TiempoMinScroll = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        Direccion = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        Pulsacion = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        Scroll = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        Movimiento = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        ClicDer = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        ClicIzq = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        ClicMedio = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        EjecAcciones = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);
        ModoOperacion = RecValor(Cadena, iPosFin + 1, ',', &iPosFin);

        int pos =0;
        EEPROM.writeShort(pos, (int)COD_INI);
        pos += sizeof(int);
        EEPROM.writeShort(pos,MultiplicadorX);
        pos += sizeof(int);
        EEPROM.writeShort(pos,MultiplicadorY);
        pos += sizeof(int);
        EEPROM.writeShort(pos,PulsacionCorta);
        pos += sizeof(int);
        EEPROM.writeShort(pos,PulsacionMEdia);
        pos += sizeof(int);
        EEPROM.writeShort(pos,PulsacionLarga);
        pos += sizeof(int);
        EEPROM.writeShort(pos,PulsacionADC);
        pos += sizeof(int);
        EEPROM.writeFloat(pos,AlabeoMinNeg);
        pos += sizeof(float);
        EEPROM.writeFloat(pos,AlabeoMaxNeg);
        pos += sizeof(float);
        EEPROM.writeFloat(pos,AlabeoMinPos);
        pos += sizeof(float);
        EEPROM.writeFloat(pos,AlabeoMaxPos);
        pos += sizeof(float);
        EEPROM.writeFloat(pos,CorrecionAlabeoDer);
        pos += sizeof(float);
        EEPROM.writeShort(pos,TiempoMinScroll);
        pos += sizeof(int);
        EEPROM.writeShort(pos,Direccion);
        pos += sizeof(int);
        EEPROM.writeShort(pos,Pulsacion);
        pos += sizeof(int);
        EEPROM.writeShort(pos,Scroll);
        pos += sizeof(int);
        EEPROM.writeShort(pos,Movimiento);
        pos += sizeof(int);
        EEPROM.writeShort(pos,ClicDer);
        pos += sizeof(int);
        EEPROM.writeShort(pos,ClicIzq);
        pos += sizeof(int);
        EEPROM.writeShort(pos,ClicMedio);
        pos += sizeof(int);
        EEPROM.writeShort(pos,EjecAcciones);
        pos += sizeof(int);
        EEPROM.writeShort(pos,ModoOperacion);
        EEPROM.commit();

        Serial.println("@#M:Configuracion grabada correctamente.");
        break;
      }
	  case 'L':
      { 
        LeerConfiguracion();  
        break;
      }
	  case 'A':
      { //Márgen alabeo
        int d;
        d = RecValor(Cadena, p, ';', &iPosFin);

        iNumServo = RecValor(Cadena, p, ',', &iPosFin);
        iValor = RecValor(Cadena, iPosFin + 1, ';', &iPosFin);

        break;
      }
    }
  }
}

int ComprobarCRC(int CRC, char *cad)
{
  int c = 0;
  int i = 0;
  
  while ((cad[i] != 0) && (i < MAX_LON_CADENA))
  {
    c += cad[i++];
  }
  Serial.println(c%100);
  if (c%100 == CRC)
    return 1;
   else
     return 0;
}

int LeerCadena(int *i, char *Cadena)
{
  char c;

  while (Serial.available() > 0)
  {
    c = Serial.read();
    if (*i < MAX_LON_CADENA-2)
    {
      switch (c)
      {
        case '\r':
          break;
        case '\n':
        case '#':
        {
            Cadena[*i] = 0;
            *i = 0;
            return 1; //FIN_LECTURA
        }
        default:
          Cadena[(*i)++] = c;
          Cadena[*i] = 0;
      }
    }
    else
    {
        Cadena[0] = 0;
        *i = 0;
        return 2;
    }
 }
 return 0;
}
int RecValor(char *Cadena, int iPosIni, char cDelimitador, int *iFinPos)
{
  char cTmp[50] = "\0";
  char cCar;
  int i,j;
  
  i = iPosIni;
  j = 0;
  cCar = Cadena[i];
  while (cCar != cDelimitador)
  {
    cTmp[j++] = cCar;
    cCar = Cadena[++i];
  }
  cTmp[j] = 0;
  *iFinPos = i;
  return atoi(cTmp);
}
char * RecCadena(char *Cadena, int iPosIni, char cDelimitador, int *iFinPos)
{
  static char cTmp[50] = "\0";
  char cCar;
  int i,j;
  
  cTmp[0] = 0;
  i = iPosIni;
  j = 0;
  cCar = Cadena[i];
  while (cCar != cDelimitador)
  {
    cTmp[j++] = cCar;
    cCar = Cadena[++i];
  }
  cTmp[j] = 0;
  *iFinPos = i;
  return cTmp;
}
float RecFloat(char *Cadena, int iPosIni, char cDelimitador, int *iFinPos)
{
  char *pCadena = RecCadena(Cadena, iPosIni, cDelimitador, iFinPos);
  return atof(pCadena);
}

void SalidaCfg()
{
        Serial.println(MultiplicadorX);
        Serial.println(MultiplicadorY);
        Serial.println(PulsacionCorta);
        Serial.println(PulsacionMEdia);
        Serial.println(PulsacionLarga);
        Serial.println(PulsacionADC);
        Serial.println(AlabeoMinNeg);
        Serial.println(AlabeoMaxNeg);
        Serial.println(AlabeoMinPos);
        Serial.println(AlabeoMaxPos);
        Serial.println(CorrecionAlabeoDer);
        Serial.println(TiempoMinScroll);
        Serial.println(Direccion);
        Serial.println(Pulsacion);
        Serial.println(Scroll);
        Serial.println(Movimiento);
        Serial.println(ClicDer);
        Serial.println(ClicIzq);
        Serial.println(ClicMedio);
}