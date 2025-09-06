# Jellyfin Custom Rows Plugin

Ein Plugin für Jellyfin 10.10.7.0, das es ermöglicht, die Startseite mit benutzerdefinierten Rows wie bei Netflix zu gestalten.

## ✨ Features (v1.0 - MVP)

- ✅ **Konfigurierbare Settings**: Admin-Panel zur Konfiguration der Custom Rows
- ✅ **UI-Integration**: Nahtlose Integration in die Jellyfin-Oberfläche
- ✅ **File Transformation**: Nutzt das bewährte File Transformation Plugin
- ⏳ **Dynamische Rows**: Genres, Recently Added, My List, etc. (kommende Features)
- ⏳ **Watchlist**: Favoriten-basierte "Meine Liste" Funktionalität (kommende Features)

## 🔧 Installation

### Abhängigkeiten
Dieses Plugin benötigt:
- **File Transformation Plugin** (v2.2.1.0 oder höher)
- **Plugin Pages** (v2.2.2.0 oder höher) - optional für erweiterte UI

### Installation Steps
1. Installiere die benötigten Abhängigkeiten:
   - File Transformation Plugin von `https://www.iamparadox.dev/jellyfin/plugins/manifest.json`
   - Plugin Pages (optional, aber empfohlen)

2. Lade das Custom Rows Plugin herunter und entpacke es in deinen Jellyfin Plugins-Ordner

3. Starte Jellyfin neu

4. Gehe zu **Dashboard > Plugins > Custom Rows** um das Plugin zu konfigurieren

## 🚀 Aktueller Stand (v1.0)

Dies ist die **Grundversion** des Plugins. Aktuell implementiert:

- ✅ Plugin-Struktur mit File Transformation Integration
- ✅ Konfigurations-UI im Admin-Dashboard
- ✅ Basis UI-Transformation (zeigt Indikator wenn aktiv)
- ✅ Grundlegende Einstellungen (Enable/Disable, Row-Limits, etc.)

## 🎯 Roadmap

### Phase 1 (v1.1) - Basis Rows
- Genre-basierte Rows
- Recently Added Row
- Basis-Styling

### Phase 2 (v1.2) - Watchlist
- "Meine Liste" via Favoriten
- Herz-Button zu "+" Button Änderung
- Sortierung nach zuletzt hinzugefügt

### Phase 3 (v1.3) - Erweiterte Features
- Random Picks Row
- "Lange nicht gesehen" Row  
- Blacklist für Genres
- Erweiterte Konfiguration

### Phase 4 (v2.0) - Netflix-like Experience
- Vollständige Netflix-ähnliche UI
- Drag & Drop Row-Reihenfolge
- Personalisierte Empfehlungen

## ⚙️ Konfiguration

Nach der Installation findest du die Einstellungen unter **Dashboard > Plugins > Custom Rows**.

### Verfügbare Einstellungen:

#### Allgemeine Einstellungen
- **Enable Custom Rows**: Aktiviert/deaktiviert das Plugin
- **Max Rows**: Maximale Anzahl der Rows (Standard: 8)
- **Max Items per Row**: Maximale Items pro Row (Standard: 20)
- **Min Items per Row**: Minimale Items pro Row (Standard: 5)

#### Row-Typen (für kommende Versionen)
- **Genre Rows**: Automatische Genre-basierte Rows
- **Recently Added**: Kürzlich hinzugefügte Inhalte
- **My List**: Favoriten-basierte Watchlist
- **Random Picks**: Zufällige Inhalte zur Entdeckung
- **Not Watched**: Lange nicht gesehene Inhalte

#### Erweiterte Einstellungen
- **Custom CSS**: Eigenes CSS für Styling
- **Debug Mode**: Erweiterte Logs für Entwicklung

## 🛠️ Entwicklung

### Projektstruktur
```
Jellyfin.Plugin.CustomRows/
├── Configuration/
│   ├── PluginConfiguration.cs
│   └── configPage.html
├── Services/
│   └── UITransformationService.cs
├── Plugin.cs
├── PluginServiceRegistrator.cs
└── Jellyfin.Plugin.CustomRows.csproj
```

### Kompilierung
```bash
dotnet build -c Release
```

### Architektur
Das Plugin nutzt die bewährte Architektur der IAmParadox27 Plugins:
- **File Transformation**: Für UI-Modifikationen ohne direkte Web-Änderungen
- **Plugin Pages**: Für nahtlose Admin-UI Integration (optional)
- **Reflection-based Integration**: Sichere Plugin-zu-Plugin Kommunikation

## 🐛 Debugging

1. Aktiviere **Debug Mode** in den Plugin-Einstellungen
2. Überprüfe die Jellyfin Server-Logs für Custom Rows Meldungen
3. Browser Developer Tools für Client-seitige Issues

## 📝 Lizenz

Dieses Projekt steht unter der MIT-Lizenz.

## 🤝 Beitragen

Contributions sind willkommen! 

1. Fork das Repository
2. Erstelle einen Feature-Branch
3. Committe deine Änderungen
4. Erstelle einen Pull Request

## ⚠️ Hinweise

- **Beta-Version**: Dies ist eine frühe Version - verwende sie vorsichtig in Produktionsumgebungen
- **Kompatibilität**: Getestet mit Jellyfin 10.10.7.0
- **Abhängigkeiten**: File Transformation Plugin ist zwingend erforderlich

## 🆘 Support

Bei Problemen:
1. Überprüfe die Server-Logs
2. Stelle sicher, dass alle Abhängigkeiten installiert sind  
3. Erstelle ein GitHub Issue mit detaillierten Informationen

---

**Happy Streaming! 🎬**