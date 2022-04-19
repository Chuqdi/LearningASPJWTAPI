using LearningAPI.Data;
using static LearningAPI.Utils.Exceptions;

namespace LearningAPI.Services
{
    public class SuperHero
    {
        private readonly AppDbContext _db;
        private static readonly string superHeroNotFoundMessage = "Super Hero With this ID does not exist";
        public SuperHero(AppDbContext db)
        {
            _db = db;
        }

        public Models.SuperHero create(Models.SuperHero superHero)
        {
            _db.SuperHeroes.Add(superHero);
            _db.SaveChanges();
            return superHero;

        }
        public List<Models.SuperHero> getAll()
        {
            return _db.SuperHeroes.ToList();
        }

        public Models.SuperHero getSingle(int Id)
        {
            return _db.SuperHeroes.Where(s => s.Id == Id).FirstOrDefault();

        }

        public Models.SuperHero delete(int Id)
        {
            Models.SuperHero dbSuperHero = getSingle(Id);
            if (dbSuperHero == null) throw new SuperHeroNoFound(superHeroNotFoundMessage);

            _db.SuperHeroes.Remove(dbSuperHero);
            _db.SaveChanges();


            return dbSuperHero;
        }

        public Models.SuperHero update(int Id, Models.SuperHero superHero)
        {
            Models.SuperHero dbSuperHero = getSingle(Id);
            if (dbSuperHero == null) throw new SuperHeroNoFound(superHeroNotFoundMessage);
            dbSuperHero.Place = superHero.Place;
            dbSuperHero.LastName = superHero.LastName;
            dbSuperHero.FirstName = superHero.FirstName;
            dbSuperHero.HeroName = superHero.HeroName;


            var updatedSuperHero = _db.SuperHeroes.Update(dbSuperHero);
            _db.SaveChanges();
            return updatedSuperHero.Entity;
        }
    }
}
