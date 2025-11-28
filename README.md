# Lab 4 – Konsumera Web-API
Av: **Afroviti Xhoga**  
Klass: **DSO25**

Denna applikation är en konsollapp som använder HTTP-förfrågningar för att kommunicera med två offentliga web-API:er:

1. **GitHub REST API** – Hämtar information om .NET Foundations publika repos  
2. **Zippopotam.us API** – (VG-del) Hämtar postnummer, latitud och longitud för Montvale, New Jersey

---

## 🚀 Funktionalitet

### ✔️ 1. GitHub API (G-delen)
Programmet skickar en HTTP GET till:

https://api.github.com/orgs/dotnet/repos

Applikationen deserialiserar JSON-resultatet och visar följande fält:

- **Name**
- **Description**
- **HTML URL**
- **Homepage**
- **Watchers**
- **Pushed at**

All data skrivs ut i ett format som liknar kravbilden från uppgiften.

---

### ✔️ 2. Zippopotam.us API (VG-delen)
Programmet hämtar information om:

📍 *Montvale, New Jersey (07645)*  

Applikationen visar:

- Land
- Postnummer
- Ort
- Delstat
- Latitud
- Longitud

---

## 🛠️ Teknologier som används

- **C# .NET 8**
- **HttpClient**
- **System.Text.Json**
- **JSON-deserialisering med attribut**
- **Visual Studio 2022**
- **Git + GitHub**

---

## 📁 Projektstruktur

Lab4WebApi/
│
├── GitHubRepo.cs // Klassmodell för GitHub-JSON
├── ZipPlace.cs // Klassmodell för platsinformation
├── ZipResponse.cs // Rootmodell för Zippopotam.us JSON
├── Program.cs // Huvudprogram + HTTP-anrop
└── Lab4WebApi.csproj


---

## ▶️ Körning

Konsollappen startas genom:

dotnet run

Programmet kör automatiskt:

1. Hämtning av GitHub-repos  
2. Hämtning av information från Zippopotam.us  

---

## 📌 Kravuppfyllelse

| Krav | Status |
|------|--------|
| HTTP GET mot GitHub API | ✔️ |
| JSON-deserialisering via System.Text.Json | ✔️ |
| Visa alla efterfrågade fält | ✔️ |
| Extra uppgift för VG | ✔️ Fullt genomförd |
| GitHub Repo med push | ✔️ |
| README.md | ✔️ |

---

## 📝 Personlig Reflektion (VG)

Detta projekt gav mig större förståelse för HTTP-kommunikation, API:er och JSON-hantering i C#.  
Jag lärde mig:

- hur HttpClient fungerar  
- hur man hanterar headers  
- hur man deserialiserar komplex JSON  
- hur API:er returnerar olika datastrukturer  
- hur viktigt korrekt JSON-modellering är  

Labben var mycket lärorik och gav en bra introduktion till hur moderna system kommunicerar i verkligheten.

---

## 🔗 GitHub Repo

👉 **https://github.com/AfrovitiXhoga/Lab4WebApi**

---



