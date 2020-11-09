create table End_User(
userId integer not null primary key IDENTITY(1, 1),
email varchar (255) unique not null,
passwordValue varchar(255) not null,
);

create table Grocery_List (
  listId int not null primary key IDENTITY(1, 1),
  title varchar(255) not null,
  locationSite varchar(255) not null,
  dateCreated date,
  userId int not null,
  foreign key (userId) references End_User(userId)
);

create table Items(
	itemId integer not null primary key IDENTITY(1, 1),
	itemName VARCHAR(255) NOT NULL,
	quantity int not null,
	listId int not null,
	foreign key (listId) references Grocery_List(listId)
);