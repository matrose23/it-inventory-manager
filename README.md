# IT Inventory Manager

Der **IT Inventory Manager** ist eine einfache Konsolenanwendung in C#.

Mit diesem Programm können IT-Geräte wie Laptops, Monitore oder Drucker verwaltet werden.

Die Anwendung wurde im Rahmen einer Projektwoche entwickelt, um praktische Erfahrungen mit **C#, objektorientierter Programmierung und Datenverwaltung** zu sammeln.

---

## Funktionen

Die Anwendung bietet folgende Funktionen:

- Neues Gerät hinzufügen
- Alle Geräte anzeigen
- Geräte bearbeiten
- Geräte löschen
- Gerätestatus ändern (Available / Assigned / InRepair / Retired)
- Geräte nach Hersteller suchen
- Geräte nach Standort suchen
- Gerät über Seriennummer finden
- Geräte nach Status filtern
- Allgemeine Suchfunktion
- Eingabeprüfung für Pflichtfelder

---

## Datenspeicherung

Die Gerätedaten werden in einer **JSON-Datei (devices.json)** gespeichert.

Beim Start der Anwendung werden vorhandene Daten automatisch aus der Datei geladen.

Wenn ein Gerät hinzugefügt, geändert oder gelöscht wird, werden die Daten wieder gespeichert.

Dadurch bleiben die Informationen auch nach dem Neustart des Programms erhalten.

---

## Verwendete Technologien

Für dieses Projekt wurden folgende Technologien verwendet:

- **C#**
- **.NET Konsolenanwendung**
- **System.Text.Json** für die Datenspeicherung
- **LINQ** für Such- und Filterfunktionen
- **Git und GitHub** für Versionskontrolle

---

## Projektstruktur
```
ITInventoryManager
│
├── Models
│   ├── Device.cs
│   └── User.cs
│
├── Services
│   └── InventoryService.cs
│
├── Enums
│   └── DeviceStatus.cs
│
├── Program.cs
└── README.md
```
---

## Programm starten

1. Repository klonen git clone https://github.com/hasantuncay/it-inventory-manager.git

2. Projekt in **Visual Studio 2022** öffnen

3. Programm starten

4. Über das Konsolenmenü Geräte verwalten

---

## Beispiel Menü
===== IT Inventory Manager =====
```
1 - Gerät hinzufügen
2 - Alle Geräte anzeigen
3 - Gerät löschen
4 - Status ändern
5 - Gerät bearbeiten
6 - Geräte nach Status anzeigen
7 - Geräte nach Hersteller suchen
8 - Geräte nach Standort suchen
9 - Gerät nach Seriennummer suchen
10 - Allgemeine Suche
0 - Programm beenden
```
---

## Projektfortschritt

Tag 1 – Projektidee und Einrichtung des Projekts  
Tag 2 – Erstellung der Klassenstruktur (Device, User, Enum)  
Tag 3 – Geräte hinzufügen und anzeigen  
Tag 4 – Geräte bearbeiten, löschen und Status ändern  
Tag 5 – Such- und Filterfunktionen implementieren  
Tag 6 – JSON-Datenspeicherung und Eingabevalidierung implementieren  
Tag 7 – Tests, Diagramme und Dokumentation erstellen

---

## Lernziele des Projekts

Dieses Projekt zeigt grundlegende Konzepte der Programmierung:

- Objektorientierte Programmierung (OOP)
- Klassen und Methoden
- Datenverwaltung mit Listen
- LINQ-Abfragen
- JSON-Datenspeicherung
- Konsolenanwendungen in C#

---

## Autor
Hasan Tuncay
