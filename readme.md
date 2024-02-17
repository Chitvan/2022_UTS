Purpose: 
a visual representation of a movie theater seat reservation system that includes a front end written in Unity and a backend data storage in runtime memory and json blobs of files. Features
include a list of movies and times and a view of seats that are available and already reserved. It is functional, but not production quality. It was build in approximately 10 hours spread over 5 days. 
- Day 1: Plan 
- Day 2: Build UI 
- Day 3: Build data base with UI
- Day 4: Add backend support
- Day 5: Polish
- 

Running the application: 
- When you start the project in Unity, you'd need to add a username to make or view reservations. 
- If you use the username **Jacinda** or **Greta**, you can view existing reservations. 
- Existing reservations are saved in screenReservations.json. If you select date Feb 16 or 5 and select 7:30pm slot for Harvey movie, you can see some reserved slots in the seat map. 
- There is some prepopulated data. Otherwise, while the application is playing, the data will be saved in dictionaries in NetworkDataBridge.cs

Known bugs/polish items:
1. The UI is built with desktop and web resolutions in mind. Mobile screen resolutions would involve setting up anchor points, which was not in scope.
2. The screen seat maps could be dynamically generated. They get loaded from prefabs at the moment and could use seatMaps.json file instead. Since Unity's out-of-the-box Json parser does not read a 2D array, I ended up making prefabs of screen maps instead and made a script Scripts > Tools > SeatGridGenerator.cs to help me with it.
3. The data does not persist from a play session. For this, I exposed a method in NetworkDataBridge.cs where it can be added or perhaps on a 'Save' button in main menu.
