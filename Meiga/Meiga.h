//*******************************************  FUNCIONES  *****************************************
#define ESPERA_CFG  3000

#ifndef EXTERN_FILE
struct PosAccion
{
  int Codigo;
  int Variable;
  float Min;
  float Max;
  int TiempoMinSeg;
  int TiempoMaxSeg;
  long MsActivacion;
};
#endif

int  recta (int p1x, int p1y, int p2x, int p2y, int ms, int dir);
void Circunferencia(int cx, int cy, int r, int ms, float ang_ini, float ang_fin, int dir);
bool FinContador(int c);
void IniciarContadorMs(int c, long ms);
void Configuracion();
void LOG_controlacciones();
void LOG_FIN();
bool LOG_SALIDA();
void LOG(String s1, int s2, bool rc);
void LOG(String s1, long s2, bool rc);
void LOG(String s1, float s2, bool rc);
void LOG(String s1, String s2, bool rc);
bool Posicion(float n, PosAccion pa);
void DefinirAcciones();
void EstablecerCentroRaton(int cx, int cy);
void updateFiltered();
void updateGiro();
void Salida();
void SalidaPosicion();
void Calibrar();
int  ControlAcciones();
void DesactivarMeiga();
void ActivarMeiga();
void ControlRaton();
void LeerConfiguracion();
void setup(void); 
void loop(void);
