#include <SPI.h>
#include <MFRC522.h>
#include "config.h"
#include "functions.h"
#include "communications.h"

MFRC522 mfrc522(SS_PIN, RST_PIN);

void setup() {
  
  SPI.begin();
  mfrc522.PCD_Init();
  establishContact();
}


void loop() {
  // Look for new RFID cards
  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    // Get the UID of the card
    byte* uidPtr = mfrc522.uid.uidByte;
    uint32_t uid = ((uint32_t)uidPtr[0] << 24) | ((uint32_t)uidPtr[1] << 16) | ((uint32_t)uidPtr[2] << 8) | (uint32_t)uidPtr[3];
    // Print the UID to the serial port
    //Serial.println(uid, BIN); //original uint out


    String binaryStr = "1"; // start with a leading 1
    for (int i = 31; i >= 0; i--) {
      binaryStr += ((uid >> i) & 1) ? '1' : '0'; // extract each bit and append to string
    }
    Serial.println(binaryStr);

    // Halt the tag to stop reading
    mfrc522.PICC_HaltA();
    // Stop the encryption process
    mfrc522.PCD_StopCrypto1();
  }
}

