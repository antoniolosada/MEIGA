#define LECTURA_FIN       1
#define MAX_LON_CADENA    100
#define COD_INI           12347

extern char Cadena[MAX_LON_CADENA];

int ComprobarCRC(int CRC, char *cad);
int LeerCadena(int *i, char *Cadena);
int RecValor(char *Cadena, int iPosIni, char cDelimitador, int *iFinPos);
char * RecCadena(char *Cadena, int iPosIni, char cDelimitador, int *iFinPos);
