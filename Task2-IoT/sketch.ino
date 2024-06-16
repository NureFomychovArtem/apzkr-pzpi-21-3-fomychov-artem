#include <WiFi.h>
#include <time.h>
#include <HTTPClient.h>
#include <Adafruit_ILI9341.h>
#include <ArduinoJson.h>

//Значення Wi-Fi-мережі для отримання доступу
#define WIFI_SSID "Wokwi-GUEST"
#define WIFI_PASSWORD ""
#define WIFI_CHANNEL 6

String serverUrl = "https://localhost:44320/api/Attendance";
DynamicJsonDocument doc(1024);
String fingerprint = "";

#define tft_cs 15
#define tft_dc 2
#define tft_mosi 23
#define tft_sclk 18

Adafruit_ILI9341 tft = Adafruit_ILI9341(tft_cs, tft_dc);

#define WIDTH 320
#define HEIGHT 240

#define THERMISTOR_PIN 14
float temperature;

void setup(void) {
  Serial.begin(115200);

  // Підключення до мережі Wi-Fi
  Serial.print("Connecting to a WiFi network");
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD, WIFI_CHANNEL);
  while (WiFi.status() != WL_CONNECTED) {
    delay(100);
    Serial.print(".");
  }
  Serial.println(" Connected!");
  Serial.println("IP: " + WiFi.localIP().toString());

  configTime(0, 0, "pool.ntp.org");
  while (!time(nullptr)) {
    delay(1000);
    Serial.println("Waiting for time synchronization...");
  }

  tft.begin();
  tft.setRotation(1);
}

void loop() {
  fingerprint = scanFingerprint();
  Serial.print("Fingerprint: ");
  Serial.println(fingerprint);

  temperature = readTemperature();
  Serial.print("Temperature: ");
  Serial.println(temperature);

  struct tm timeinfo;
  if (!getLocalTime(&timeinfo)) {
    Serial.println("Failed to obtain time");
  }
  const int bufferSize = 50;
  char buffer[bufferSize];

  // Форматування часу за допомогою strftime()
  strftime(buffer, bufferSize, "%Y-%m-%dT%H:%M:%S.000Z", &timeinfo);

  // Конвертуємо рядок char в String
  String timeString = String(buffer);

  Serial.print("Time: ");
  Serial.println(timeString);

  HTTPClient http;
  http.begin(serverUrl.c_str());
  http.addHeader("Content-Type", "application/json");

  String json = "{\"fingerprint\":" + fingerprint + "\"time\":" + timeString + ",\"temperature\":" + temperature + "}";
  int httpResponseCode = http.POST(json);
  Serial.println(httpResponseCode);

  if (httpResponseCode > 0) {
    String response = http.getString();
    Serial.println(response);
    } else {
      Serial.println("Failed to update data");
    }

  http.end();
  delay(1000);
}

float readTemperature() {
  int rawValue = analogRead(THERMISTOR_PIN);

  float temperature = map(rawValue, 0, 4095, 36.6, 50);

  return temperature;
}

String scanFingerprint() {
  String result = "";
  for (int y = 0; y < HEIGHT; y++) {
    for (int x = 0; x < WIDTH; x++) {
      tft.drawPixel(x, y, x * y);
      result += (x + y);
    }
  }

  return result;
}
  