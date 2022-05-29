# ProjectZen
Download Project
Extract the project to desire location
In project run **CMD** and enter following command **dotnet run**
Open browser and go to the following url **https://localhost:5001/swagger/index.html**
Swaggere UI will open, after that you can pass desire parametars to retrive the data.

Example: 
![image](https://user-images.githubusercontent.com/20918713/170870304-47bf73ee-6061-4cd2-9da8-317633ecfde9.png)


Result:
![image](https://user-images.githubusercontent.com/20918713/170870344-97131783-68c1-4f1a-841f-694f79c62c28.png)


Also in project there is **Dockerfile** that can be used to crate a **docker image**.

Once the docket images is created and microservise has been started in Contaniner.
You can call the api with parametars.
**Set of dates
  Base currency
  Target currency**

Example: [http://localhost:3000/Exchangerate/2017-02-23,2012-02-23,2020-02-23/USD/RSD](http://localhost:3000/Exchangerate/2018-02-01,%202018-02-15,%202018-03-01/SEK/NOK)

OutPut:
![image](https://user-images.githubusercontent.com/20918713/170870627-921a2410-7553-47f9-864b-7f481691ee35.png)

![image](https://user-images.githubusercontent.com/20918713/170870912-438917c8-6b9e-4e5b-b2ed-4041c78ea458.png)


