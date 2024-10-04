//Arduino Nano - CPU Atmega168

int contador = 1;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
}

void loop() {
  contador += 1;
  contador = contador % 100;
  // put your main code here, to run repeatedly:
  Serial.print("@LP:");
  Serial.print(digitalRead(2));
  Serial.print(",");
  Serial.print(digitalRead(4));
  Serial.print(";");
  Serial.print(contador);
  Serial.println(";#.");
  delay(100);
}
