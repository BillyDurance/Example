create table End_User(
userId integer not null primary key IDENTITY(1, 1),
email varchar (255) unique not null,
passwordValue varchar(255) not null,
constraint NoSpecialCharacters 
       check (email not like '%[^A-Z0-9]%'),
	   check (passwordValue not like '%[^A-Z0-9]%')
);

create table Grocery_List (
  listId int not null primary key IDENTITY(1, 1),
  title varchar(255) not null,
  location varchar(255) not null,
  dateCreated date,


  userId int not null,

  foreign key (userId) references End_User(userId)
);



 
