void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.print("@LP:");
  Serial.print(digitalRead(2));
  Serial.print(",");
  Serial.println(digitalRead(4));
  delay(100);
}
