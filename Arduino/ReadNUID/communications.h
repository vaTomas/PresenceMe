String readSerialInputString();
void clearSerialBuffer();


void establishContact() {
  Serial.begin(9600);
  while (!Serial); // Wait until serial port is opened

  while (true) {
    uint8_t pingCode = random();
    Serial.println(uint8ToBinaryString(pingCode));

    // delay(200); // ping try wait

    if (Serial.available()) {
      String machineResponse = readSerialInputString();
      uint8_t pingFeedback = ~binaryStringToUint8(machineResponse);

      if(pingFeedback == pingCode){
        Serial.println("00000000");
        break;
      }
    }

    clearSerialBuffer();
  }
}


String readSerialInputString(){
  String serialString = Serial.readString();
  // serialString = removeLastCharacter(serialString);
  return serialString;
}


void clearSerialBuffer() {
  while (Serial.available()) {
    Serial.read();
  }
}
