# WoW Dragonflight M+ Rating Tracker

This project is a .NET-based application designed to track and compare Mythic Plus (M+) ratings for characters in World of Warcraft's Dragonflight expansion. It utilizes the Raider.io API to fetch character profiles and M+ scores, providing a user-friendly interface built with WPF for players to view and compare their progress.

## Features

- **Character Lookup**: Search for WoW characters by name to view their M+ ratings, specialization, and other relevant information.
- **Comparison Tool**: Compare M+ ratings and specs between two WoW characters.
- **Real-Time Data**: Fetches real-time data from the Raider.io API.
- **Image Display**: Shows character thumbnails alongside their M+ data.

## Tools

- C#
- WPF (XAML)

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2019 or later (recommended for development)

### Installation

1. Clone the repository:
2. Open the solution file in Visual Studio.
3. Restore NuGet packages and build the solution.

### Usage

1. Run the backend, then WPF.
2. Enter a WoW character name and press "Submit" to fetch and display the character's M+ rating and other details.
3. Use the comparison feature to compare two characters by entering their names in the respective input fields.

## Development

### Structure

- `ApiService`: Responsible for API calls to Raider.io.
- `MplusController`: Manages the user interface and interactions.
- `Models`: Contains data models like `Mplus` for API response handling.

### Adding Features

- The project can be extended with additional features like more detailed character profiles, broader API data integration, etc.
- Follow existing coding conventions for consistency.
