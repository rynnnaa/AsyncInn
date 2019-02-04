https://asyninnn20190203111405.azurewebsites.net/

# AsyncInnn
Hotel Async Inn is a hotel managing system.
Hotels have a 1:many relationship with hotel rooms, which means that each hotel can have multiple rooms. Rooms indicates a specific room type that can vary based on layout. A room type can belong to many hotels. There are a variety of amenities such as air-conditioning, a coffee maker, etc. A room can have many different amenities which is represented in the 1:many relationship.RoomAmenities: This is a pure join table that has a combination of AmenitiesID and RoomID as a composite key. The many:1 relationship assures that an amenity will only be applied to a room once.

How to use:
Clone the repository
Open the AsyncInn solution in Visual Studio
Run IIS Express
Navigate to website in your browser

Visual:
![Schema](https://github.com/rynnnaa/AsyncInn/blob/master/AsynInnn/Assets/SchemaAsyncInn.png)
![Website](https://github.com/rynnnaa/AsyncInn/blob/master/AsynInnn/Assets/HomePage.PNG)
