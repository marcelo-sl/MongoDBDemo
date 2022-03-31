using MongoDataAccess.DataAccess;
using MongoDB.Driver;
using MongoDataAccess.Models;

ChoreDataAccess db = new ChoreDataAccess();

await db.CreateUser(new UserModel { FirstName = "Marcelo", LastName = "Lima" });

var users = await db.GetAllUsers();

var chore = new ChoreModel() 
{ 
    AssignedTo = users.First(), 
    ChoreText = "Mow the Lawn", 
    FrequencyInDays = 7 
};

await db.CreateChore(chore);

var chores = await db.GetAllChores();

var newChore = chores.First();
newChore.LastCompleted = DateTime.Now;

await db.CompleteChore(newChore);