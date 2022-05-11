drop table resturants;
drop table reviews;

create table resturants (
    ID int not null PRIMARY KEY IDENTITY(1,1) CHECK (ID > 0),
    Name NVARCHAR(255) NOT NULL,
    Address nvarchar(255) NOT NULL,
    City nvarchar(255),
    State nvarchar(255),
    Zipcode int NOT NULL CHECK (ZIPCODE > 0),
    Country nvarchar(255)
)

create table reviews (
    ID int not null PRIMARY KEY IDENTITY(1,1) CHECK (ID > 0),
    ResturantID int not null,
    Rating decimal(5,1) not null CHECK (Rating <= 5.0 AND Rating >= 1.0),
    Review NVARCHAR(MAX)
)

Alter table reviews add FOREIGN key (ResturantID) REFERENCES resturants(id);

insert into resturants (name, Address, City, State, Zipcode, Country) VALUES ('Black Angus Steakhouse', '4724 E Indiana Ave', 'Spokane', 'WA', 99216, 'USA');

insert into reviews (ResturantID, Rating, Review) VALUES (1, 5.0, 'I loved the place! Wonderful steaks and our server was very nice and polite to us. Would recomend to a friend.');

insert into reviews (ResturantID, Rating, Review) VALUES (1, 1.0, 'Bad food ew.');

Select * from resturants as res 
    left join reviews as rev on res.id = rev.ResturantID

Select ID from resturants where Name like '%Black%'

Select * from users
Select * from resturants
Select * from reviews