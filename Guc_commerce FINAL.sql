create database GUCommerce
create table Users
(
username varchar(20),
first_name varchar(20), 
last_name varchar(20),
password varchar(20),
email varchar(50),
primary key(username)
)

create table User_mobile_numbers
(
username varchar(20), 
mobile_number varchar(20),
primary key(username,mobile_number),
foreign key(username) references users on update cascade on delete cascade
)

create table User_Addresses
(
username varchar(20), 
address varchar(100),
primary key(username,address),
foreign key(username) references users on update cascade on delete cascade
)

create table Customer
(
username varchar(20),
points int, 
primary key(username),
foreign key(username) references Users on update cascade on delete cascade
)

create table Admins
(
username varchar(20),
primary key(username),
foreign key(username) references Users on update cascade on delete cascade
)

create table Vendor
(
username varchar(20),
activated bit, 
company_name varchar(20), 
bank_acc_no varchar(20),
admin_username varchar(20),
primary key(username),
foreign key(username) references Users on update cascade on delete cascade,
foreign key(admin_username) references Admins  --on delete set to null (DO IT YOURSELF IN THE PROCEDURE)
)

create table Delivery_Person
(
username varchar(20),
is_activated bit,
primary key(username),
foreign key(username) references Users on update cascade on delete cascade
)

create table Credit_Card
(
number varchar(20), 
expiry_date date, 
cvv_code varchar(4),
primary key(number)
)

create table delivery
(
delivery_id int identity,
delivery_type varchar(20) not null,
time_duration int not null,
fees decimal(5,3) not null,
admin_username varchar(20),
primary key(delivery_id),
foreign key(admin_username) references Admins on update cascade on delete set null
)

create table Orders
(
order_no int identity, 
order_date datetime, 
total_amount decimal(10,2), 
cash_amount decimal(10,2), 
credit_amount decimal(10,2), 
payment_type varchar(20), 
order_status varchar(20), 
remaining_days int, 
time_limit datetime,
Gift_Card_code_used varchar(10),
customer_name varchar(20),
delivery_id int, 
creditCard_number varchar(20),
foreign key(Gift_Card_code_used) references Giftcard on update cascade on delete set null,
foreign key(customer_name) references Customer,  --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
foreign key(delivery_id) references delivery,  --on delete set to null (DO IT YOURSELF IN THE PROCEDURE)
foreign key(creditCard_number) references credit_card,  --on delete set to null (DO IT YOURSELF IN THE PROCEDURE)
primary key(order_no)
)

create table Product
(
serial_no int identity,
vendor_username varchar(20), 
product_name varchar(20) not null,
category varchar(20) not null, 
product_description text not null, 
price decimal(10,2) not null, 
final_price decimal(10,2),
color varchar(20) not null,
available bit,
rate int, 
customer_username varchar(20),
customer_order_id int,
primary key(serial_no),
foreign key(customer_order_id) references Orders on update cascade on delete set null,
foreign key(vendor_username) references Vendor,  --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
foreign key(customer_username) references Customer  --on delete set to null (DO IT YOURSELF IN THE PROCEDURE)
)

create table CustomerAddstoCartProduct
(
serial_no int,
customer_name varchar(20),
foreign key(customer_name) references customer on update cascade on delete  cascade,
foreign key(serial_no) references product,  --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
primary key(serial_no, customer_name)
)

create table Todays_Deals
(
deal_id int identity,
deal_amount int not null,
expiry_date datetime not null,
admin_username varchar(20),
primary key(deal_id), 
foreign key(admin_username) references Admins on update cascade on delete set  null
)

create table Todays_Deals_Product
(
deal_id int, 
serial_no int,
foreign key(deal_id) references Todays_Deals on update cascade on delete cascade,
foreign key(serial_no) references Product, --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
primary key(deal_id,serial_no) 
)

create table offer
(
offer_id int identity,
offer_amount int not null,
expiry_date datetime not null,
primary key(offer_id)
)

create table offersOnProduct
(
offer_id int,
serial_no int,
primary key (offer_id, serial_no),
foreign key(offer_id) references offer on update cascade on delete cascade,
foreign key(serial_no) references Product on update cascade on delete cascade
)

create table Customer_Question_Product
(
serial_no int,
customer_name varchar(20) not null,
question varchar(50) not null,
answer text,
primary key(serial_no, customer_name),
foreign key(serial_no) references Product on update cascade on delete cascade,
foreign key(customer_name) references Customer --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
)

create table Wishlist
(
username varchar(20),
name varchar(20),
primary key(username, name),
foreign key(username) references Customer on update cascade on delete cascade
)

create table Giftcard
(
code varchar(10),
expiry_date datetime not null,
amount int not null,
username varchar(20) not null,
primary key(code),
foreign key(username) references Admins on update cascade on delete cascade
)

create table Wishlist_Product
(
username varchar(20),
wish_name varchar(20),
serial_no int,
primary key (username, wish_name, serial_no),
foreign key(username, wish_name) references Wishlist, --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
foreign key(serial_no) references Product --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
)

create table Admin_Customer_Giftcard
(
code varchar(10),
customer_name varchar(20),
admin_username varchar(20),
remaining_points int,
primary key(code, customer_name, admin_username),
foreign key(code) references Giftcard, --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
foreign key(customer_name) references Customer on update cascade on delete cascade,
foreign key(admin_username) references Admins --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
)

create table Admin_Delivery_Order
(
delivery_username varchar(20),
order_no int,
admin_username varchar(20),
delivery_window varchar(50),
primary key(delivery_username, order_no),
foreign key(delivery_username) references Delivery_person,
foreign key(order_no) references Orders on update cascade on delete cascade, --on delete cascade (DO IT YOURSELF IN THE PROCEDURE)
foreign key(admin_username) references Admins --on delete set to null (DO IT YOURSELF IN THE PROCEDURE)
)

create table Customer_CreditCard
(
customer_name varchar(20),
cc_number varchar(20),
primary key(customer_name, cc_number),
foreign key(customer_name) references Customer on update cascade on delete cascade,
foreign key(cc_number) references Credit_Card on update cascade on delete cascade
)

EXEC makeOrder 'ali.elbadry'
select * from Orders
go
create proc customerRegister
@username varchar(20),@first_name varchar(20),@last_name varchar(20),@password varchar(20),@email varchar(50) as 
insert into Users(username, first_name, last_name, password, email) 
values(@username, @first_name, @last_name, @password, @email)
insert into Customer(username) values(@username)

go
create proc vendorRegister
@username varchar(20),@first_name varchar(20),@last_name varchar(20),@password varchar(20),@email varchar(50), 
@company_name varchar(20),@bank_acc_no varchar(20) as 
insert into Users(username, first_name, last_name, password, email) 
values(@username, @first_name, @last_name, @password, @email)
insert into Vendor(username, company_name, bank_acc_no) 
values(@username, @company_name, @bank_acc_no)

go
create proc userLogin
@username varchar(20), @password varchar(20), @success bit output , @type int output as
if exists(select * from Users where username = @username and password = @password) AND exists(select * from Customer where username = @username)
begin set @success = 1 set @type = 0 end
else if  exists(select * from Users where username = @username and password = @password) AND exists(select * from Vendor where username = @username) 
begin set @success = 1 set @type = 1 end
else if  exists(select * from Users where username = @username and password = @password) AND exists(select * from Admins where username = @username)
begin set @success = 1 set @type = 2 end
else if  exists(select * from Users where username = @username and password = @password) AND exists(select * from Delivery_Person where username = @username)
begin set @success = 1 set @type = 3 end
else begin set @success = 0 set @type = -1 end

go
create proc addMobile
@username varchar(20), @mobile_number varchar(20) as
insert into User_mobile_numbers values(@username, @mobile_number)

go
create proc addAddress
@username varchar(20), @address varchar(100) as
insert into User_Addresses values(@username, @address)

go
create proc showProducts as
select * from Product


go
create proc ShowProductsbyPrice as
select * from Product p order by p.price asc

go
create proc searchbyname 
@text varchar(20) as
select * from Product p where p.product_name like concat(@text,'%')

go
create proc AddQuestion
@serial int, @customer varchar(20), @Question varchar(50) as
insert into Customer_Question_Product(serial_no, customer_name, question) 
values(@serial, @customer, @Question)

GO
create proc addToCart
@customername varchar(20), 
@serial int
AS
If (select available from Product where serial_no=@serial)=1
Insert into CustomerAddstoCartProduct  values(@serial, @customername)

GO
create proc removefromCart
@customername varchar(20), 
@serial int
AS
delete from CustomerAddstoCartProduct where customer_name=@customername and serial_no=@serial

GO
create proc createWishlist
@customername varchar(20),
@name varchar(20)
AS
Insert into Wishlist values(@customername,@name)

GO
create proc AddtoWishlist
@customername varchar(20), 
@wishlistname varchar(20), 
@serial int
AS
Insert into Wishlist_Product values(@customername,@wishlistname,@serial)

GO
Create proc removefromWishlist
@customername varchar(20), 
@wishlistname varchar(20), 
@serial int
AS
delete from Wishlist_Product where serial_no=@serial and wish_name=@wishlistname and username=@customername

GO

create proc showWishlistProduct
@customername varchar(20), 
@name varchar(20)
AS
select * from Product P where P.serial_no IN (select WP.serial_no from Wishlist_Product WP where WP.username=@customername and WP.wish_name=@name)

GO
create proc viewMyCart
@customer varchar(20)
AS
select * from Product P where P.serial_no IN (select serial_no from CustomerAddstoCartProduct CACP where CACP.customer_name=@customer)

GO

Create proc calculatepriceOrder
@customername varchar(20),
@sum decimal(10,2) OUTPUT
AS
select @sum=sum(P.final_price) 
FROM CustomerAddstoCartProduct CACP INNER JOIN Product P on CACP.serial_no= P.serial_no
where CACP.customer_name=@customername

GO
create Proc productsinorder 
@customername varchar(20), 
@orderID int
AS
update Product set customer_username=@customername, customer_order_id=@orderID,available=0 where serial_no in (select serial_no from CustomerAddstoCartProduct CACP where CACP.customer_name=@customername)
delete from CustomerAddstoCartProduct where customer_name<>@customername and serial_no in (select serial_no from CustomerAddstoCartProduct CACP where CACP.customer_name=@customername)

GO
create Proc emptyCart
@customername varchar(20)
AS
delete from CustomerAddstoCartProduct where customer_name=@customername

drop proc makeOrder
GO
create Proc makeOrder
@customername varchar(20),
@success bit output
AS
declare @total decimal(10,2)
EXEC calculatepriceOrder  @customername , @total output
if(@total is null)
begin
	set @success=0
end
else
begin
	declare @currenttime datetime
	set @currenttime=CURRENT_TIMESTAMP
	Insert into Orders (customer_name, total_amount, order_status, order_date) values(@customername, @total, 'not processed', @currenttime)
	DECLARE @order_num int
	select @order_num=order_no from Orders where customer_name=@customername and total_amount=@total and order_status='not processed' and order_date=@currenttime
	EXEC productsinorder @customername, @order_num
	EXEC emptyCart @customername
	set @success=1
end

GO
create  proc cancelOrder
@orderid int,
@customername varchar(20),
@success bit OUTPUT
AS
DECLARE @amount decimal(10,2)
IF (select order_status from Orders where order_no=@orderid)='not processed' or (select order_status from Orders where order_no=@orderid)='in process'
BEGIN
set @success=1
if CURRENT_TIMESTAMP<=(select expiry_date from Giftcard G inner join Admin_Customer_Giftcard ACG on G.code=ACG.code where ACG.customer_name=(select customer_name from orders where order_no=@orderid))
BEGIN
if (select cash_amount from Orders where order_no = @orderid) is null or (select cash_amount from Orders where order_no = @orderid) =0
if (select credit_amount from Orders where order_no = @orderid) is null or (select credit_amount from Orders where order_no = @orderid) =0
set @amount= (select total_amount  from Orders where order_no=@orderid)
else
set @amount= (select total_amount  from Orders where order_no=@orderid)-(select credit_amount from Orders where order_no=@orderid)
else
set @amount= (select total_amount  from Orders where order_no=@orderid)-(select cash_amount from Orders where order_no=@orderid)
UPDATE Admin_Customer_Giftcard set remaining_points=remaining_points+@amount where customer_name=(select customer_name from orders where order_no=@orderid)
UPDATE Customer set points=points+@amount where username=(select customer_name from orders where order_no=@orderid)
END
UPDATE Product set customer_username=null ,customer_order_id=null,available=1 where customer_order_id=@orderid
delete from Orders where order_no=@orderid 
END
ELSE
set @success=0

GO
Create proc returnProduct
@serialno int, 
@orderid int
AS
 DECLARE @amount decimal(10,2)
if CURRENT_TIMESTAMP<=(select expiry_date from Giftcard G inner join Admin_Customer_Giftcard ACG on G.code=ACG.code where ACG.customer_name=(select customer_name from orders where order_no=@orderid))
BEGIN
 if (select cash_amount from Orders where order_no = @orderid) is null or (select cash_amount from Orders where order_no = @orderid) =0
 begin
if (select credit_amount from Orders where order_no = @orderid) is null or (select credit_amount from Orders where order_no = @orderid) =0
begin
  set @amount= (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid )
  UPDATE Admin_Customer_Giftcard set remaining_points=remaining_points+@amount where customer_name=(select customer_name from orders where order_no=@orderid)
  UPDATE Customer set points=points+@amount where username=(select customer_name from orders where order_no=@orderid)
end
else
  if (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid )> (select credit_amount from Orders where order_no=@orderid)
  BEGIN
  set @amount= (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid)-(select credit_amount from Orders where order_no=@orderid)
  UPDATE Admin_Customer_Giftcard set remaining_points=remaining_points+@amount where customer_name=(select customer_name from orders where order_no=@orderid)
  UPDATE Customer set points=points+@amount where username=(select customer_name from orders where order_no=@orderid)
  UPDATE orders set credit_amount = 0 where order_no = @orderid 
  END
  else 
  begin
  UPDATE orders set credit_amount = credit_amount - (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid) where order_no = @orderid   
  end
 end
 else
 Begin
 if (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid )> (select cash_amount from Orders where order_no=@orderid)
  BEGIN
  set @amount= (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid)-(select cash_amount from Orders where order_no=@orderid)
  UPDATE Admin_Customer_Giftcard set remaining_points=remaining_points+@amount where customer_name=(select customer_name from orders where order_no=@orderid)
  UPDATE Customer set points=points+@amount where username=(select customer_name from orders where order_no=@orderid)
  UPDATE orders set cash_amount = 0 where order_no = @orderid
  END
  else 
  begin
   UPDATE orders set cash_amount = cash_amount - (select final_price from Product where serial_no=@serialno and customer_order_id=@orderid) where order_no = @orderid   
  end
 end
END
Update Product set customer_username=null, customer_order_id=null, available=1 where serial_no=@serialno and customer_order_id=@orderid
Update orders set total_amount=total_amount-(select final_price from Product where serial_no=@serialno and order_no=@orderid)

GO
create proc ShowproductsIbought
@customername varchar(20)
AS
select * FROM Product P where P.customer_username=@customername

GO
create proc rate
@serialno int, 
@rate int ,
@customername varchar(20)
AS
UPDATE Product set rate= @rate where serial_no=@serialno and customer_username=@customername



GO
CREATE PROC SpecifyAmount
@customername varchar(20), 
@orderID int,
@cash decimal(10,2), 
@credit decimal(10,2),
@case int OUTPUT
AS
set @case=0
IF @cash is null or @cash=0
BEGIN 
IF(select total_amount from orders where order_no=@orderID)<@credit
set @case=1;
ELSE IF (select total_amount from orders where order_no=@orderID)-@credit<=(select points from Customer where username=@customername)
Begin
set @case=2;
Update Orders set payment_type='credit',credit_amount=@credit,cash_amount=@cash where order_no=@orderID
declare @amountPoints int
set @amountPoints=(select total_amount from orders where order_no=@orderID)-@credit
update Customer set points=points-@amountPoints where username=(select customer_name from orders where order_no=@orderID)
update Admin_Customer_Giftcard set remaining_points=remaining_points-@amountPoints where customer_name=(select customer_name from orders where order_no=@orderID)
IF(select total_amount from orders where order_no=@orderID)-@credit>0 
update orders set Gift_Card_code_used=(select Gift_Card_code_used from Admin_Customer_Giftcard where customer_name=(select customer_name from orders where order_no=@orderID) )where order_no=@orderID
END
END
IF @credit is null or @credit=0
BEGIN
IF(select total_amount from orders where order_no=@orderID)<@cash
set @case=1;
ELSE IF  (select total_amount from orders where order_no=@orderID)-@cash<=(select points from Customer where username=@customername)
Begin
set @case=2;
Update Orders set payment_type='cash' where order_no=@orderID
update Orders set credit_amount=@credit
update Orders set cash_amount=@cash
set @amountPoints=(select total_amount from orders where order_no=@orderID)-@cash
update Customer set points=points-@amountPoints where username=(select customer_name from orders where order_no=@orderID)
update Admin_Customer_Giftcard set remaining_points=remaining_points-@amountPoints where customer_name=(select customer_name from orders where order_no=@orderID)
IF(select total_amount from orders where order_no=@orderID)-@cash>0 
update orders set Gift_Card_code_used =(select code from Admin_Customer_Giftcard where customer_name=(select customer_name from orders where order_no=@orderID) )where order_no=@orderID
END
END

GO
CREATE PROC AddCreditCard
@creditcardnumber varchar(20), 
@expirydate date , 
@cvv varchar(4),
@customername varchar(20)
AS
INSERT INTO Credit_Card values(@creditcardnumber,@expirydate,@cvv)
INSERT INTO Customer_CreditCard values(@customername,@creditcardnumber)

GO
create proc ChooseCreditCard
@customer varchar(20),
@creditcard varchar(20), 
@orderid int,
@success bit  output
AS
declare @succ1 bit
declare @succ2 bit
EXEC validCreditCard  @creditcard, @customer, @succ1 OUTPUT
EXEC validOrder @orderid, @customer, @succ2 OUTPUT
if(@succ1=1 and @succ2=1)
begin
Update Orders set creditCard_number=@creditcard where order_no=@orderid
set @success=1
end
else
begin
set @success=0
end

GO
create proc vewDeliveryTypes
AS
select delivery_type,time_duration,fees from delivery

GO

create proc specifydeliverytype
@orderID int, 
@deliveryID int
AS
UPDATE Orders set delivery_id=@deliveryID where order_no=@orderID 
UPDATE Orders set remaining_days=(select time_duration from delivery where delivery_id=@deliveryID) where order_no=@orderID
UPDATE Orders set time_limit = DATEADD(day, (select time_duration from delivery where delivery_id=@deliveryID), CURRENT_TIMESTAMP) where order_no =@orderID;


GO
create proc trackRemainingDays
@orderid int, 
@customername varchar(20),
@days int output
AS 
UPDATE Orders set remaining_days= DATEDIFF(day, CURRENT_TIMESTAMP, order_date) where customer_name=@customername and order_no=@orderid	
if (select remaining_days from orders where customer_name=@customername and order_no=@orderid)<0
UPDATE Orders set remaining_days=0 where customer_name=@customername and order_no=@orderid	
select @days=remaining_days from orders where customer_name=@customername and order_no=@orderid
GO
create proc recommmend
@customername varchar(20)
AS
drop table #CategoriesCount
drop table #Top3Categories
drop table #ProductsInWishlistFromCategories
drop table #ProductsCount
drop table #Reccomendation1
select * into  #CategoriesCount FROM (select P.category, COUNT(*) AS 'Count' from CustomerAddstoCartProduct CACP INNER JOIN Product P on p.serial_no=CACP.serial_no 
where customer_name=@customername  Group by category) AS temp
Select * into #Top3Categories From (select TOP 3 category from #CategoriesCount order by count desc) AS temp2
Select * into #ProductsInWishlistFromCategories From(select P.* from Product P INNER JOIN  Wishlist_Product WP on P.serial_no=WP.serial_no Inner join #Top3Categories on P.category=#Top3Categories.category where p.serial_no not in(select serial_no From Wishlist_Product where username=@customername) and p.serial_no not in(select serial_no From CustomerAddstoCartProduct where customer_name=@customername) ) AS temp3
select * into  #ProductsCount FROM (select serial_no, product_name, count(*) AS  'count' from #ProductsInWishlistFromCategories Group by serial_no, product_name) AS temp
Select * into #Reccomendation1 FROM (select * from Product where serial_no in (select TOP 3 serial_no from #ProductsCount order by count desc) )AS temp
drop table #pairsOfCustomers 
drop table #otheruserscount 
drop table #top3similairUsers 
drop table #ProductsCount2
drop table #ProductsInWishlistFromSimilairUsers 
drop table #Reccomendation2
select * into #pairsOfCustomers from (select C1.serial_no AS s1,  C2.serial_no AS s2, C1.customer_name AS cus1, C2.customer_name AS cus2 from  CustomerAddstoCartProduct C1 inner join CustomerAddstoCartProduct C2 on C1.serial_no=C2.serial_no where C1.customer_name=@customername and c1.customer_name<>c2.customer_name) as temp1
select * into #otheruserscount from (select cus2, count(*) AS 'count' from #pairsOfCustomers Group by cus2) AS temp
select * into #top3similairUsers from(select top 3 cus2 from #otheruserscount order by count desc) as temp
Select * into #ProductsInWishlistFromSimilairUsers From(select P.* from Product P INNER JOIN  Wishlist_Product WP on P.serial_no=WP.serial_no Inner join #top3similairUsers on WP.username=#top3similairUsers.cus2 where p.serial_no not in(select serial_no From Wishlist_Product where username=@customername) and p.serial_no not in(select serial_no From CustomerAddstoCartProduct where customer_name=@customername) ) AS temp3
select * into  #ProductsCount2 FROM (select serial_no, product_name, count(*) AS  'count' from #ProductsInWishlistFromSimilairUsers Group by serial_no, product_name) AS temp
Select * into #Reccomendation2 FROM (select * from Product where serial_no in (select TOP 3 serial_no from #ProductsCount2 order by count desc) )AS temp
select * from #Reccomendation1 
select * from #Reccomendation2


go
create proc postProduct
@vendorUsername varchar(20), @product_name varchar(20) ,@category varchar(20), @product_description text , @price decimal(10,2), @color varchar(20) as
insert into Product(vendor_username, product_name, category, product_description, price, final_price, color, available) 
values(@vendorUsername, @product_name, @category, @product_description, @price, @price, @color,1)

go 
create proc vendorviewProducts
@vendorname varchar(20) as
select p.* from Product p where p.vendor_username = @vendorname

go
create proc EditProduct
@vendorname varchar(20), @serialnumber int, @product_name varchar(20), @category varchar(20), @product_description text, @price decimal(10,2), @color varchar(20) as
update Product set product_name = @product_name, category = @category, product_description = @product_description, price = @price, color = @color 
where serial_no = @serialnumber AND vendor_username = @vendorname

go 
create proc deleteProduct
@vendorname varchar(20), @serialnumber int as
delete from Product where serial_no = @serialnumber AND vendor_username = @vendorname

go
create proc viewQuestions
@vendorname varchar(20) as
select cpq.* from Customer_Question_Product cpq, Product p where p.vendor_username = @vendorname AND p.serial_no = cpq.serial_no

go
create proc answerQuestions
@vendorname varchar(20), @serialno int, @customername varchar(20), @answer text as
update Customer_Question_Product set answer = @answer where customer_name = @customername AND serial_no = @serialno 
AND @vendorname = (select vendor_username from Product p where p.serial_no = @serialno) 

go 
create proc addOffer
@offeramount int, @expiry_date datetime as
insert into offer(offer_amount, expiry_date) values(@offeramount, @expiry_date)

go 
create proc checkOfferonProduct
@serial int, @activeoffer bit output as
if exists(select * from offersOnProduct where serial_no = @serial) set @activeoffer = 1
else set @activeoffer = 0

go
create proc checkandremoveExpiredoffer
@offerid int as
if GETDATE()>(select expiry_date from offer where offer_id = @offerid) 
begin
DECLARE @Discount decimal(10,2);
SELECT @Discount = o.offer_amount FROM offer o WHERE o.offer_id = @offerid;
update Product set final_price = final_price + (price *@Discount/100) 
where serial_no = (select serial_no from offersOnProduct oop where oop.offer_id = @offerid)
delete from offersOnProduct where offer_id = @offerid
delete from offer where  offer_id=@offerid
end

go
create proc applyOffer
@vendorname varchar(20), @offerid int, @serial int as
if exists(select p.* from Product p where p.vendor_username = @vendorname AND p.serial_no = @serial)
begin
declare @discount decimal(10,2)
select @discount = offer_amount from offer where offer_id = @offerid
declare @AD BIT
exec checkTodaysDealOnProduct @serial, @AD output
declare @AO bit
exec checkOfferonProduct @serial, @AO output
if (@AO = 0) 
begin
if current_timestamp < (select expiry_date from offer where offer_id = @offerid) 
begin update Product set final_price = (price - price*(@discount/100)) where serial_no = @serial
insert into offersOnProduct values(@offerid, @serial) end
end
else
begin print('an active offer or todays deals already exists on product') end
end
GO

CREATE PROC activateVendors
@admin_username varchar(20),
@vendor_username varchar(20)
AS
UPDATE Vendor SET activated = 1, admin_username = @admin_username WHERE username = @vendor_username

GO

CREATE PROC inviteDeliveryPerson
@delivery_username varchar(20),
@delivery_email varchar(50)
AS
INSERT INTO Users (username,email) VALUES (@delivery_username,@delivery_email);
INSERT INTO Delivery_Person (username , is_activated ) VALUES (@delivery_username,0);

GO

CREATE PROC reviewOrders
AS
SELECT * FROM Orders

GO

CREATE PROC updateOrderStatusInProcess
@order_no int
AS 
UPDATE Orders SET order_status = 'In process' WHERE order_no = @order_no;

GO

CREATE PROC addDelivery

@delivery_type varchar(20),
@time_duration int,
@fees decimal(5,3),
@admin_username varchar(20)
AS
INSERT INTO delivery (delivery_type, time_duration,fees,admin_username) VALUES (@delivery_type,@time_duration,@fees,@admin_username);


GO
CREATE PROC assignOrdertoDelivery
@delivery_username varchar(20),
@order_no int,
@admin_username varchar(20)
AS
INSERT INTO Admin_Delivery_Order (delivery_username,order_no,admin_username) VALUES (@delivery_username,@order_no,@admin_username);

GO

CREATE PROC createTodaysDeal
@deal_amount int,
@admin_username varchar(20),
@expiry_date datetime
AS
INSERT INTO Todays_Deals (deal_amount,expiry_date,admin_username) VALUES (@deal_amount,@expiry_date,@admin_username);

GO

CREATE PROC checkTodaysDealOnProduct
@serial_no INT,
@activeDeal BIT OUTPUT
AS
IF (EXISTS (SELECT * FROM Todays_Deals_Product TDP WHERE TDP.serial_no = @serial_no))
SET @activeDeal = 1;
ELSE 
SET @activeDeal = 0;

GO 
CREATE PROC addTodaysDealOnProduct
@deal_id int, 
@serial_no int
AS
DECLARE @AD BIT
EXEC checkTodaysDealOnProduct @serial_no, @AD OUTPUT
DECLARE @AO BIT
EXEC checkOfferonProduct @serial_no, @AO OUTPUT
IF (@AD = 1 or @AO=1 )
print 'There is already a Deal or an offer on this product'
ELSE
BEGIN
INSERT INTO Todays_Deals_Product  (deal_id,serial_no) VALUES (@deal_id ,@serial_no);
declare @amount decimal(10,2)
SELECT @amount= TD.deal_amount FROM Todays_Deals TD WHERE TD.deal_id = @deal_id
UPDATE Product  SET final_price = price - (price * ((@amount)/100)) WHERE serial_no = @serial_no;
END

GO
CREATE PROC removeExpiredDeal
@deal_id int
AS
DECLARE @expiry_date datetime
SELECT @expiry_date = expiry_date FROM Todays_Deals WHERE deal_id = @deal_id
IF(GETDATE() > @expiry_date)
BEGIN
UPDATE Product SET final_price = price WHERE serial_no = (SELECT TDP.serial_no FROM Todays_Deals_Product TDP WHERE TDP.deal_id =@deal_id and TDP.serial_no = serial_no);
DELETE FROM Todays_Deals WHERE deal_id = @deal_id;
END


GO

CREATE PROC createGiftCard
@code varchar(10),
@expiry_date datetime,
@amount int,
@admin_username varchar(20)
AS
INSERT INTO Giftcard  (code,expiry_date,amount,username) VALUES (@code,@expiry_date,@amount,@admin_username)

GO

CREATE PROC removeExpiredGiftCard
@code varchar(10)
AS 
DECLARE @expiry_date datetime
SELECT @expiry_date = expiry_date FROM Giftcard WHERE code = @code
IF(GETDATE() > @expiry_date)
BEGIN
UPDATE Customer SET points = 0 where username in (select customer_name from Admin_Customer_Giftcard where code=@code)
DELETE FROM Admin_Customer_Giftcard WHERE code = @code;
DELETE FROM Giftcard WHERE code = @code;
END


GO

CREATE PROC checkGiftCardOnCustomer
@code varchar(10) ,@activeGiftCard BIT OUTPUT
AS
IF (EXISTS (SELECT * FROM Admin_Customer_Giftcard ACG WHERE ACG.code = @code))
SET @activeGiftCard = 1;
ELSE 
SET @activeGiftCard = 0;	

GO

CREATE PROC giveGiftCardtoCustomer
@code varchar(10),
@customer_name varchar(20),
@admin_username varchar(20)
AS
IF (EXISTS (SELECT * FROM Admin_Customer_Giftcard ACG WHERE ACG.customer_name = @customer_name))
BEGIN
print('user has alrady a gift card')
END
ELSE
BEGIN
UPDATE Customer SET points = (SELECT Gc.amount from Giftcard Gc WHERE Gc.code = @code) WHERE username = @customer_name
INSERT INTO Admin_Customer_Giftcard (code ,customer_name ,admin_username ,remaining_points) VALUES (@code,@customer_name,@admin_username,(SELECT Gc.amount from Giftcard Gc WHERE Gc.code = @code))
END

GO

CREATE PROC acceptAdminInvitation
@delivery_username varchar(20)
AS
UPDATE Delivery_Person SET is_activated = 1 WHERE username = @delivery_username;

GO

CREATE PROC deliveryPersonUpdateInfo
@username varchar(20),
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@email varchar(50)
AS 
UPDATE Users SET first_name = @first_name, last_name = @last_name, password = @password where email = @email and username = @username

GO

CREATE PROC viewmyorders
@deliveryperson varchar(20)
AS 
SELECT * from Orders WHERE order_no = (SELECT order_no from Admin_Delivery_Order ADO WHERE ADO.delivery_username = @deliveryperson); 

GO

CREATE PROC specifyDeliveryWindow
@delivery_username varchar(20),
@order_no int,
@delivery_window varchar(50)
AS
UPDATE Admin_Delivery_Order SET delivery_window = @delivery_window WHERE delivery_username = @delivery_username AND order_no = @order_no

GO

CREATE PROC updateOrderStatusOutforDelivery
@order_no int
AS
UPDATE Orders SET order_status = 'Out for delivery' WHERE order_no = @order_no

GO

CREATE PROC updateOrderStatusDelivered
@order_no int
AS
UPDATE Orders SET order_status = 'Delivered' WHERE order_no = @order_no

GO

create proc myOrders
@customername varchar(20)
AS
select order_no, total_amount from Orders where customer_name=@customername

GO

create proc myCreditCard
@customername varchar(20)
AS
select * from Customer_CreditCard where customer_name=@customername

GO

create proc validCreditCard
@creditCard varchar(20),
@customer varchar(20),
@success bit OUTPUT
AS
if(exists(select * from Customer_CreditCard where customer_name=@customer and cc_number=@creditCard))
set @success=1
else
set @success=0

Go
create proc validOrder
@ordId int,
@customer varchar(20),
@success bit OUTPUT
AS
if(exists(select * from Orders where customer_name=@customer and order_no=@ordId))
set @success=1
else
set @success=0

GO
CREATE PROC viewWishLists
@customer varchar(20)
AS
SELECT W.name FROM Wishlist W WHERE W.username = @customer;

