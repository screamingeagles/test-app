using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using test_app.Controllers;
using test_app.Model;

namespace test_app.Service
{
    public interface ITransactions
    {       
        IEnumerable<StudentObject>  GetStudents();
        IEnumerable<RelationObject> GetRelations();
        StudentObject AddStudent(StudentObject param);
        StudentObject UpdateStudent(StudentObject param, int? countryId);
        StudentObject GetStudent(int ID, bool family = false, bool nationality = false);
        FamilyObject GetFamilyMember(int FamilyMemberID);
        IEnumerable<FamilyObject> GetStudentFamilyMembers(int StudentID);
        FamilyObject AddFamilyMember(int StudentID, FamilyObject param);
        FamilyObject GetFamilyMembers(int ID, int NationalityID);        
        FamilyObject UpdateFamilyMember(int ID, FamilyObject param);
        FamilyObject UpdateFamilyMemberNationality(int ID, int countryId);
        IEnumerable<FamilyListObject> GetFamilyMembersList(int ID);
        int DeleteFamilyMember(int ID);
        IEnumerable<NationalityObject> GetAllNationalities();
        NationalityObject AddCountry(NationalityObject param);
        int AddNationality(string Country);
    }
    public class Transactions : ITransactions
    {
        private readonly dbModel db;
        private readonly ILogger<Transactions> _logger;

        public Transactions(ILogger<Transactions> logger, dbModel db)
        {
            this.db = db;
            this._logger = logger;
        }

        public IEnumerable<RelationObject> GetRelations()
        {
            try
            {
                IQueryable<RelationObject> result = db.Relations
                    .Select(x => new RelationObject
                    {
                        RelationshipId = x.RelationshipId,
                        RelationshipName= x.RelationshipName
                    }).AsQueryable();

                return result.ToList();
            }
            catch (Exception exi)
            {
                _logger.LogInformation("Exception at Get Relationships: " + exi.Message);
                return null;
            }
        }
        
        public IEnumerable<StudentObject>  GetStudents()
        {            
            try
            {
                IQueryable<StudentObject> result = db.Students
                    .Select(x => new StudentObject{
                    ID= x.ID,
                     firstName = x.FirstName,
                     lastName = x.LastName,
                     dateOfBirth = x.DateOfBirth,
                     nationalityId = x.NationalityId.HasValue? x.NationalityId.Value : 0
                }).AsQueryable();

                return result.ToList();
            }
            catch(Exception exi)
            {
                _logger.LogInformation("Exception at Get: " + exi.Message);
                return null;
            }
        }

        public StudentObject GetStudent(int ID, bool family = false, bool nationality = false)
        {
            StudentObject result = new StudentObject();
            try
            {
                Student student = db.Students.Find(ID);

                if (student != null)
                {
                    result.ID = student.ID;
                    result.firstName = student.FirstName;
                    result.lastName = student.LastName;
                    result.dateOfBirth = student.DateOfBirth;

                    if (nationality == true) {
                        result.nationalityId = student.NationalityId;
                    }

                    if (family == true) {
                        //result.relationshipId = db.FamilyMembers.Where(x => x.RelationshipId == ID).Select(x => x.ID).FirstOrDefault();
                    }
                }
                return result;
            }
            catch (Exception exi) {
                _logger.LogInformation("Exception at Getting Student Details: " + exi.Message);
                return null;
            }
        }
        
        public StudentObject AddStudent(StudentObject param)
        {
            try
            {
                Student student = new Student();
                student.FirstName = param.firstName;
                student.LastName = param.lastName;
                student.DateOfBirth = param.dateOfBirth;
                if (param.nationalityId.HasValue) { student.NationalityId = param.nationalityId; }
                
                db.Students.Add(student);
                db.SaveChanges();
                param.ID = student.ID;

                return param;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception-Add: " + exi.Message);
                return null;
            }
        }

        public StudentObject UpdateStudent(StudentObject param, int? countryId)
        {
            try
            {
                int StudentID = param.ID.HasValue ? param.ID.Value : 0;
                Student student = db.Students.Find(StudentID);

                if (student != null)
                {
                    student.FirstName = param.firstName;
                    student.LastName = param.lastName;
                    student.DateOfBirth = param.dateOfBirth;
                    if (param.nationalityId.HasValue)
                    {
                        student.NationalityId = param.nationalityId;
                    }
                    if (countryId.HasValue){
                        student.NationalityId = countryId.Value;
                    }
                    db.Students.Update(student);
                    db.SaveChanges();
                }
                else
                {
                    _logger.LogInformation("No Matching Record Found In DB");
                }
                return param;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception-Update: " + exi.Message);
                return null;
            }
        }

        public IEnumerable<FamilyObject> GetStudentFamilyMembers(int StudentID)
        {
            try
            {
                IQueryable<FamilyObject> result = db.FamilyMembers.Where(x => x.RelationshipId == StudentID)
                    .Select(x => new FamilyObject
                    {
                        ID = x.ID,
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        dateOfBirth = x.DateOfBirth,
                        relationshipId = x.RelationshipId
                    }).AsQueryable();

                return result.ToList();
            }
            catch (Exception exi)
            {
                _logger.LogInformation("Exception at GetStudentFamilyMembers: " + exi.Message);
                return null;
            }
        }

        public FamilyObject AddFamilyMember(int StudentID, FamilyObject param)
        {
            try {
                FamilyMember family = new FamilyMember();
                family.FirstName = param.firstName;
                family.LastName = param.lastName;
                family.DateOfBirth = param.dateOfBirth;
                family.RelationshipId = param.relationshipId;
                family.StudentID = StudentID;
                if (param.nationalityId.HasValue) { family.NationalityId = param.nationalityId; }               
                db.FamilyMembers.Add(family);
                db.SaveChanges();
                
                param.ID = family.ID;
                //param.relationshipId = StudentID;
                return param;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception Add Family: " + exi.Message);
                return null;
            }
        }

        public FamilyObject UpdateFamilyMember(int ID, FamilyObject param)
        {
            try {
                FamilyMember family= db.FamilyMembers.Find(ID);

                if (family != null)
                {
                    family.FirstName = param.firstName;
                    family.LastName = param.lastName;
                    family.DateOfBirth = param.dateOfBirth;
                    family.RelationshipId = param.relationshipId;
                    if (param.nationalityId.HasValue) {
                        family.NationalityId = param.nationalityId.Value;
                    }
                    db.FamilyMembers.Update(family);
                    db.SaveChanges();
                    param.ID = ID;
                }
                else {
                    _logger.LogInformation("No Matching Record Found In DB");
                }
                return param;
            }
            catch (Exception exi) {
                _logger.LogError("Exception-Update: " + exi.Message);
                return null;
            }
        }

        public int DeleteFamilyMember(int ID)
        {
            try
            {
                FamilyMember member = db.FamilyMembers.Find(ID);
                if (member != null) {
                    db.FamilyMembers.Remove(member);
                    return db.SaveChanges();
                }
                else {
                    return 0;
                }
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception-Delete: " + exi.Message);
                return -1;
            }
        }

        public FamilyObject GetFamilyMember(int FamilyMemberID)
        {
            FamilyObject fo = new FamilyObject();
            try
            {
                FamilyMember fm = db.FamilyMembers.Find(FamilyMemberID);

                if (fm != null)
                {
                    fo.ID = fm.ID;
                    fo.firstName = fm.FirstName;
                    fo.lastName = fm.LastName;
                    fo.dateOfBirth = fm.DateOfBirth;
                    fo.nationalityId = fm.NationalityId;
                    fo.relationshipId = fm.RelationshipId;
                    fo.studentID = fm.StudentID;
                }
                return fo;
            }
            catch (Exception exi)
            {
                _logger.LogInformation("Exception at Get Family Member With Nationality: " + exi.Message);
                return null;
            }
        }

        public FamilyObject GetFamilyMembers(int ID, int NationalityID)
        {
            try
            {
                System.Linq.Expressions.Expression<Func<FamilyMember, bool>> predicate = x => x.ID == ID && x.NationalityId != null && x.NationalityId == NationalityID;

                return db.FamilyMembers.Where(predicate)
                                        .Select(x => new FamilyObject
                                        {
                                            ID = x.ID,
                                            firstName = x.FirstName,
                                            lastName = x.LastName,
                                            dateOfBirth = x.DateOfBirth,
                                            relationshipId = x.RelationshipId,
                                            nationalityId = x.NationalityId
                                        }).FirstOrDefault();

            }
            catch (Exception exi)
            {
                _logger.LogInformation("Exception at Get Family Member With Nationality: " + exi.Message);
                return null;
            }
        }

        public FamilyObject UpdateFamilyMemberNationality(int ID, int countryId)
        {
            FamilyObject obj = new FamilyObject();
            try
            {
                FamilyMember family = db.FamilyMembers.Find(ID);

                if (family != null)
                {
                    family.NationalityId = countryId;                    
                    db.FamilyMembers.Update(family);
                    db.SaveChanges();

                    obj.ID = family.ID;
                    obj.firstName = family.FirstName;
                    obj.lastName = family.LastName;
                    obj.dateOfBirth = family.DateOfBirth;
                    obj.relationshipId = family.RelationshipId;
                    obj.nationalityId = family.NationalityId;
                }
                else
                {
                    _logger.LogInformation("No Matching Record Found In DB");
                }
                return obj;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception-Update: " + exi.Message);
                return null;
            }
        }


        public IEnumerable<FamilyListObject> GetFamilyMembersList(int ID)
        {

            try
            {
                var master = (from m in db.FamilyMembers
                              join d in db.Nationalities
                              on m.NationalityId equals d.NationalityId into Details
                              from x in Details.DefaultIfEmpty()
                              where (m.StudentID == ID)
                              select new
                              {
                                  id = m.ID,
                                  firstname = m.FirstName,
                                  lastname = m.LastName,
                                  dateOfBirth = m.DateOfBirth,
                                  nationalityId = m.NationalityId,
                                  countryName = x.CountryName == null ? "" : x.CountryName,
                                  relationshipId = m.RelationshipId,
                                  studenID = m.StudentID
                              }).ToList();

                IEnumerable<FamilyListObject> result = master.Join(db.Relations,
                     m => m.relationshipId,
                     d => d.RelationshipId,
                     (m, d) => new { family = m, relation = d })
                     .Select(x => new FamilyListObject
                     {
                         ID = x.family.id,
                         firstName = x.family.firstname,
                         lastName = x.family.lastname,
                         dateOfBirth = x.family.dateOfBirth,
                         relationshipId = x.family.relationshipId,
                         relationshipName = x.relation.RelationshipName,
                         nationalityId = x.family.nationalityId,
                         countryName =x.family.countryName,
                         studentID = x.family.studenID
                     }).ToList();
                
                return result;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception-Update: " + exi.Message);
                return null;
            }
        }

        public IEnumerable<NationalityObject> GetAllNationalities()
        {
            // Gets all nationalities in the system
            // [GET] /api/Nationalitie

            try
            {
                IQueryable<NationalityObject> result = db.Nationalities
                    .Select(x => new NationalityObject {
                       NationalityId = x.NationalityId,
                       CountryName = x.CountryName,
                    }).AsQueryable();

                return result.ToList();
            }
            catch (Exception exi)
            {
                _logger.LogInformation("Exception at Get: " + exi.Message);
                return null;
            }
        }

        public NationalityObject AddCountry(NationalityObject param)
        {
            try {
                Nationality n = new Nationality();
                n.CountryName = param.CountryName;
                db.Nationalities.Add(n);
                db.SaveChanges();
                param.NationalityId = n.NationalityId;
                return param;
            }
            catch (Exception exi) {
                _logger.LogError("Exception-Add: " + exi.Message);
                return null;
            }

        }
        
        public int AddNationality(string Country)
        {
            try
            {
                Nationality n = new Nationality();
                n.CountryName = Country;
                db.Nationalities.Add(n);
                db.SaveChanges();
                return n.NationalityId;
            }
            catch (Exception exi)
            {
                _logger.LogError("Exception Add Nationality: " + exi.Message);
                return -1;
            }
        }

    }
}
