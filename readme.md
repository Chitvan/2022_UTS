Hi,

I enjoyed working on this test. Here is a general approach I used to divide my time:
- Day 1: Plan 
- Day 2: Build UI 
- Day 3: Build data base with UI
- Day 4: Add backend support
- Day 5: Polish 


Running the application: 
- When you start the project in Unity, you'd need to add add a username to make or view reservations. 
- If you use the username **Jacinda** or **Greta**, you can view existing reservations. 
- Existing reservations are saved in screenReservations.json. If you select date April 4 or 5 and select 7:30pm slot for Harvey movie, you can see some reserved slots in the seat map. 
- There is some prepopulated data. Otherwise, while the application is playing, the data will be saved in dictionaries in NetworkDataBridge.cs


Notes about decisions: 
1. I made the UI with desktop and web resolutions in mind and decided not to spend time on setting up anchor points for mobile screen resolutions. 

2. I wanted to find a way that the screen seat maps could be dynamically generated. So I made the seatMaps.json file. Though it required for me to write a more extensive Json parser to read a 2D array, so I ended up making prefabs of screen maps instead. I made a script Scripts > Tools > SeatGridGenerator.cs to help me with it. 

3. I did not finish persisting the data that is generated at runtime, but exposed a method in NetworkDataBridge.cs where it can be added. 
