String uint8ToBinaryString(uint8_t value) {
  String binaryString = "";
  
  for (int i = 7; i >= 0; i--) {
    if (value & (1 << i)) {
      binaryString += "1";
    } else {
      binaryString += "0";
    }
  }
  
  return binaryString;
}


uint8_t binaryStringToUint8(String binaryString) {
  uint8_t result = 0;
  
  for (int i = 0; i < binaryString.length(); i++) {
    if (binaryString[i] == '1') {
      result |= (1 << (binaryString.length() - 1 - i));
    }
  }
  
  return result;
}


String uint8ToString(uint8_t value) {
    char buffer[4];  // Buffer to hold the string
    
    // Convert the uint8_t value to a string
    snprintf(buffer, sizeof(buffer), "%u", value);
    
    return String(buffer);  // Convert buffer to String and return
}


String removeLastCharacter(String input) {
  if (input.length() > 0) {
    input.remove(input.length() - 1);
  }
  return input;
}

