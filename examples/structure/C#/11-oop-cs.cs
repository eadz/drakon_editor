// Autogenerated with DRAKON Editor 1.23
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class Bar {
	public delegate void AnyCode();
    public interface IBaseRecord
    {
        int Id { get; }
    }
    private interface IDelRecord
    {
        void PreDeleteOuter(System.Collections.Generic.HashSet<IDelRecord> deletionList, bool master);
        void EnsureCanDelete(System.Collections.Generic.HashSet<IDelRecord> deletionList);
        void DoDelete(Bar db, System.Collections.Generic.HashSet<IDelRecord> deletionList);
    }
    public interface ICreature : IBaseRecord {
        string Description { get; set; }
    }
    public interface IManager : IHuman {
        Decimal Bonus { get; set; }
    }
    public interface IHuman : ICreature {
        string Name { get; }
    }
    public interface IEmployee : IHuman {
        double Salary { get; set; }
    }
    private int _next_creature = 1;
    private readonly Dictionary<int, Creature> _creature_pk = new Dictionary<int, Creature>();
    private readonly Dictionary<int, Manager> _manager_pk = new Dictionary<int, Manager>();
    private readonly Dictionary<int, Human> _human_pk = new Dictionary<int, Human>();
    private readonly Dictionary<int, Employee> _employee_pk = new Dictionary<int, Employee>();
    private class Human_Name_Comparer : IEqualityComparer<Human> {
        public bool Equals(Human x, Human y) {
            if (!Object.Equals(x._name, y._name)) return false;
            return true;
        }
        public int GetHashCode(Human obj) {
            int code = ((obj._name == null) ? 0 : obj._name.GetHashCode());
            return code;
        }
    }
    private readonly Dictionary<Human, Human> _human_Name = new Dictionary<Human, Human>(new Human_Name_Comparer());
    private class Creature_Dna_Comparer : IEqualityComparer<Creature> {
        public bool Equals(Creature x, Creature y) {
            if (x._dna != y._dna) return false;
            return true;
        }
        public int GetHashCode(Creature obj) {
            int code = obj._dna.GetHashCode();;
            return code;
        }
    }
    private readonly Dictionary<Creature, Creature> _creature_Dna = new Dictionary<Creature, Creature>(new Creature_Dna_Comparer());
    private class Creature : ICreature, IDelRecord {
        public readonly int _id;
        public int Id { get { return _id; } }
        public Creature(int id) {
            _id = id;
        }
        public int _dna;
        public int Dna {
            get { return _dna; }
        }
        public double _weight;
        public double Weight {
            get { return _weight; }
            set { _weight = value; }
        }
        public string _description;
        public string Description {
            get { return _description; }
            set { _description = value; }
        }
        public virtual void EnsureCanDelete(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
        }
        public virtual void DoDelete(Bar db, System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            db._creature_Dna.Remove(this);
            db._creature_pk.Remove(_id);
        }
        public virtual void PreDeleteOuter(System.Collections.Generic.HashSet<IDelRecord> deletionList, bool master) {
            if (deletionList.Contains(this)) {
                return;
            } else {
                deletionList.Add(this);
            }
            PreDeleteInner(deletionList);
        }
        public virtual void PreDeleteInner(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
        }
    }
    private readonly Creature _creature_Key = new Creature(0);
    private class Manager : Human, IManager, IDelRecord {
        public Manager(int id) : base(id) {
        }

        public override string ToString() {
            // item 433
            return "Manager " + Name;
        }
        public Decimal _bonus;
        public Decimal Bonus {
            get { return _bonus; }
            set { _bonus = value; }
        }
        public override void EnsureCanDelete(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
        }
        public override void DoDelete(Bar db, System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            db._human_Name.Remove(this);
            db._creature_Dna.Remove(this);
            db._manager_pk.Remove(_id);
            db._human_pk.Remove(_id);
            db._creature_pk.Remove(_id);
        }
        public override void PreDeleteOuter(System.Collections.Generic.HashSet<IDelRecord> deletionList, bool master) {
            if (deletionList.Contains(this)) {
                return;
            } else {
                deletionList.Add(this);
            }
            PreDeleteInner(deletionList);
        }
        public override void PreDeleteInner(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            base.PreDeleteInner(deletionList);
        }
    }
    private class Human : Creature, IHuman, IDelRecord {
        public Human(int id) : base(id) {
        }
        public string _name;
        public string Name {
            get { return _name; }
        }
        public override void EnsureCanDelete(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
        }
        public override void DoDelete(Bar db, System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            db._human_Name.Remove(this);
            db._creature_Dna.Remove(this);
            db._human_pk.Remove(_id);
            db._creature_pk.Remove(_id);
        }
        public override void PreDeleteOuter(System.Collections.Generic.HashSet<IDelRecord> deletionList, bool master) {
            if (deletionList.Contains(this)) {
                return;
            } else {
                deletionList.Add(this);
            }
            PreDeleteInner(deletionList);
        }
        public override void PreDeleteInner(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            base.PreDeleteInner(deletionList);
        }
    }
    private readonly Human _human_Key = new Human(0);
    private class Employee : Human, IEmployee, IDelRecord {
        public Employee(int id) : base(id) {
        }

        public override string ToString() {
            // item 427
            return "Employee " + Name;
        }
        public double _salary;
        public double Salary {
            get { return _salary; }
            set { _salary = value; }
        }
        public override void EnsureCanDelete(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
        }
        public override void DoDelete(Bar db, System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            db._human_Name.Remove(this);
            db._creature_Dna.Remove(this);
            db._employee_pk.Remove(_id);
            db._human_pk.Remove(_id);
            db._creature_pk.Remove(_id);
        }
        public override void PreDeleteOuter(System.Collections.Generic.HashSet<IDelRecord> deletionList, bool master) {
            if (deletionList.Contains(this)) {
                return;
            } else {
                deletionList.Add(this);
            }
            PreDeleteInner(deletionList);
        }
        public override void PreDeleteInner(System.Collections.Generic.HashSet<IDelRecord> deletionList) {
            base.PreDeleteInner(deletionList);
        }
    }
    public ICreature InsertCreature(int id, int dna, string description) {
        if ( id == 0 ) {
            id = _next_creature;
        } else {
            if (_creature_pk.ContainsKey(id)) {
                string className = _creature_pk[id].GetType().Name;
                throw new ArgumentException(String.Format(
                    "'{0}' with id '{1}' already exists.",
                    className, id));
            }
        }
        if ( id >= _next_creature ) {
            _next_creature = id + 1;
        }
        _creature_Key._dna = dna;
        if ( _creature_Dna.ContainsKey(_creature_Key)) {
            throw new ArgumentException(
              "Fields 'Dna' are not unique for 'Human'.");
        }
        var _record_ = new Creature(id);
        _record_._dna = dna;
        _record_._description = description;
        _creature_pk[id] = _record_;
        _creature_Dna[_record_] = _record_;
        return _record_;
    }
    public ICreature GetCreature(int id) {
        Creature _record_;
        if (!_creature_pk.TryGetValue(id, out _record_)) {
            return null;
        }
        return _record_;
    }
    public int CreatureCount() {
        return _creature_pk.Count;
    }
    public IEnumerable<ICreature> EachCreature() {
        foreach (KeyValuePair<int, Creature> record in _creature_pk) {
            yield return record.Value;
        }
    }
    public void DeleteCreature(ICreature record) {
        if (record == null) return;
        Creature _record_;
        var deletionList = new System.Collections.Generic.HashSet<IDelRecord>();
        if ( !_creature_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Creature' with id '{0}' does not exist.",
                record.Id));
        }
        _record_.PreDeleteOuter(deletionList, false);
        foreach (IDelRecord item in deletionList) {
            item.EnsureCanDelete(deletionList);
        }
        foreach (IDelRecord item in deletionList) {
            item.DoDelete(this, deletionList);
        }
    }
    public ICreature FindCreatureByDna(int dna) {
        Creature _record_;
        _creature_Key._dna = dna;
        if (_creature_Dna.TryGetValue(_creature_Key, out _record_)) {
            return _record_;
        } else {
            return null;
        }
    }
    public void SetCreatureDna(ICreature record, int newValue) {
        Creature _record_;
        if ( !_creature_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Creature' with id '{0}' does not exist.",
                record.Id));
        }
        if (_record_._dna == newValue) {
            return;
        }
        _creature_Key._dna = newValue;
        if ( _creature_Dna.ContainsKey(_creature_Key)) {
            throw new ArgumentException(
              "Fields 'Dna' are not unique for 'Human'.");
        }
        _creature_Dna.Remove(_record_);
        _record_._dna = newValue;
        _creature_Dna[_record_] = _record_;
    }
    public IManager InsertManager(int id, int dna, string description, string name, Decimal bonus) {
        if ( id == 0 ) {
            id = _next_creature;
        } else {
            if (_creature_pk.ContainsKey(id)) {
                string className = _creature_pk[id].GetType().Name;
                throw new ArgumentException(String.Format(
                    "'{0}' with id '{1}' already exists.",
                    className, id));
            }
        }
        if ( id >= _next_creature ) {
            _next_creature = id + 1;
        }
        var _record_ = new Manager(id);
        _record_._dna = dna;
        _record_._description = description;
        _record_._name = name;
        _record_._bonus = bonus;
        _creature_pk[id] = _record_;
        _human_pk[id] = _record_;
        _manager_pk[id] = _record_;
        _creature_Dna[_record_] = _record_;
        _human_Name[_record_] = _record_;
        return _record_;
    }
    public IManager GetManager(int id) {
        Manager _record_;
        if (!_manager_pk.TryGetValue(id, out _record_)) {
            return null;
        }
        return _record_;
    }
    public int ManagerCount() {
        return _manager_pk.Count;
    }
    public IEnumerable<IManager> EachManager() {
        foreach (KeyValuePair<int, Manager> record in _manager_pk) {
            yield return record.Value;
        }
    }
    public void DeleteManager(IManager record) {
        if (record == null) return;
        Manager _record_;
        var deletionList = new System.Collections.Generic.HashSet<IDelRecord>();
        if ( !_manager_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Manager' with id '{0}' does not exist.",
                record.Id));
        }
        _record_.PreDeleteOuter(deletionList, false);
        foreach (IDelRecord item in deletionList) {
            item.EnsureCanDelete(deletionList);
        }
        foreach (IDelRecord item in deletionList) {
            item.DoDelete(this, deletionList);
        }
    }
    public IHuman InsertHuman(int id, int dna, string description, string name) {
        if ( id == 0 ) {
            id = _next_creature;
        } else {
            if (_creature_pk.ContainsKey(id)) {
                string className = _creature_pk[id].GetType().Name;
                throw new ArgumentException(String.Format(
                    "'{0}' with id '{1}' already exists.",
                    className, id));
            }
        }
        if ( id >= _next_creature ) {
            _next_creature = id + 1;
        }
        _human_Key._name = name;
        if ( _human_Name.ContainsKey(_human_Key)) {
            throw new ArgumentException(
              "Fields 'Name' are not unique for 'Manager'.");
        }
        _human_Key._name = name;
        if ( _human_Name.ContainsKey(_human_Key)) {
            throw new ArgumentException(
              "Fields 'Name' are not unique for 'Manager'.");
        }
        var _record_ = new Human(id);
        _record_._dna = dna;
        _record_._description = description;
        _record_._name = name;
        _creature_pk[id] = _record_;
        _human_pk[id] = _record_;
        _creature_Dna[_record_] = _record_;
        _human_Name[_record_] = _record_;
        return _record_;
    }
    public IHuman GetHuman(int id) {
        Human _record_;
        if (!_human_pk.TryGetValue(id, out _record_)) {
            return null;
        }
        return _record_;
    }
    public int HumanCount() {
        return _human_pk.Count;
    }
    public IEnumerable<IHuman> EachHuman() {
        foreach (KeyValuePair<int, Human> record in _human_pk) {
            yield return record.Value;
        }
    }
    public void DeleteHuman(IHuman record) {
        if (record == null) return;
        Human _record_;
        var deletionList = new System.Collections.Generic.HashSet<IDelRecord>();
        if ( !_human_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Human' with id '{0}' does not exist.",
                record.Id));
        }
        _record_.PreDeleteOuter(deletionList, false);
        foreach (IDelRecord item in deletionList) {
            item.EnsureCanDelete(deletionList);
        }
        foreach (IDelRecord item in deletionList) {
            item.DoDelete(this, deletionList);
        }
    }
    public IHuman FindHumanByName(string name) {
        Human _record_;
        _human_Key._name = name;
        if (_human_Name.TryGetValue(_human_Key, out _record_)) {
            return _record_;
        } else {
            return null;
        }
    }
    public void SetHumanName(IHuman record, string newValue) {
        Human _record_;
        if ( !_human_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Human' with id '{0}' does not exist.",
                record.Id));
        }
        if (Object.Equals(_record_._name, newValue)) {
            return;
        }
        _human_Key._name = newValue;
        if ( _human_Name.ContainsKey(_human_Key)) {
            throw new ArgumentException(
              "Fields 'Name' are not unique for 'Manager'.");
        }
        _human_Name.Remove(_record_);
        _record_._name = newValue;
        _human_Name[_record_] = _record_;
    }
    public IEmployee InsertEmployee(int id, int dna, string description, string name, double salary) {
        if ( id == 0 ) {
            id = _next_creature;
        } else {
            if (_creature_pk.ContainsKey(id)) {
                string className = _creature_pk[id].GetType().Name;
                throw new ArgumentException(String.Format(
                    "'{0}' with id '{1}' already exists.",
                    className, id));
            }
        }
        if ( id >= _next_creature ) {
            _next_creature = id + 1;
        }
        var _record_ = new Employee(id);
        _record_._dna = dna;
        _record_._description = description;
        _record_._name = name;
        _record_._salary = salary;
        _creature_pk[id] = _record_;
        _human_pk[id] = _record_;
        _employee_pk[id] = _record_;
        _creature_Dna[_record_] = _record_;
        _human_Name[_record_] = _record_;
        return _record_;
    }
    public IEmployee GetEmployee(int id) {
        Employee _record_;
        if (!_employee_pk.TryGetValue(id, out _record_)) {
            return null;
        }
        return _record_;
    }
    public int EmployeeCount() {
        return _employee_pk.Count;
    }
    public IEnumerable<IEmployee> EachEmployee() {
        foreach (KeyValuePair<int, Employee> record in _employee_pk) {
            yield return record.Value;
        }
    }
    public void DeleteEmployee(IEmployee record) {
        if (record == null) return;
        Employee _record_;
        var deletionList = new System.Collections.Generic.HashSet<IDelRecord>();
        if ( !_employee_pk.TryGetValue(record.Id, out _record_)) {
            throw new ArgumentException(String.Format(
                "'Employee' with id '{0}' does not exist.",
                record.Id));
        }
        _record_.PreDeleteOuter(deletionList, false);
        foreach (IDelRecord item in deletionList) {
            item.EnsureCanDelete(deletionList);
        }
        foreach (IDelRecord item in deletionList) {
            item.DoDelete(this, deletionList);
        }
    }

    public static void Equal(object expected, object actual) {
        // item 346
        //PutObj(expected);
        //PutObj(actual);
        //Put("\n");
        // item 343
        if (Object.Equals(expected, actual)) {
            
        } else {
            // item 325
            if (expected is System.Collections.IEnumerable) {
                // item 331
                if (actual is System.Collections.IEnumerable) {
                    // item 334
                    var expectedEn = (System.Collections.IEnumerable)expected;
                    var actualEn = (System.Collections.IEnumerable)actual;
                    // item 345
                    List<object> exList = expectedEn.Cast<object>().ToList();
                    List<object> acList = actualEn.Cast<object>().ToList();
                    // item 335
                    if (exList.Count == acList.Count) {
                        // item 3380001
                        int i = 0;
                        while (true) {
                            // item 3380002
                            if (i < exList.Count) {
                                
                            } else {
                                break;
                            }
                            // item 340
                            Equal(exList[i], acList[i]);
                            // item 3380003
                            i++;
                        }
                    } else {
                        // item 347
                        string message = 
                        String.Format("Collections have different sizes: expected={0}, actual={1}", 
                        	exList.Count, acList.Count);
                        // item 337
                        throw new Exception(message);
                    }
                } else {
                    // item 333
                    throw new Exception("Both should be IEnumerable");
                }
            } else {
                // item 328
                if (actual is System.Collections.IEnumerable) {
                    // item 329
                    throw new Exception("Both should be IEnumerable");
                } else {
                    // item 341
                    throw new Exception("Objects are not equal.");
                }
            }
        }
    }

    public static void ExpectException(AnyCode code) {
        // item 362
        bool caught = false;
        try {
            code();
        }
        catch {
            caught = true;
        }
        // item 363
        if (caught) {
            
        } else {
            // item 366
            throw new Exception("Exception expected but not thrown.");
        }
    }

    public static void Main() {
        // item 403
        Bar db = new Bar();
        // item 257
        IManager gandalf = db.InsertManager(0, 10101, "blue", "Gandalf", 10000m);
        IEmployee bilbo   = db.InsertEmployee(0, 10102, "yellow", "Bilbo", 1000);
        IEmployee fedor   = db.InsertEmployee(0, 10103, "green", "Fedor", 2000);
        SetWeight(gandalf, 102);
        SetWeight(bilbo, 55);
        SetWeight(fedor, 57);
        // item 318
        Equal("blue", gandalf.Description);
        Equal("Gandalf", gandalf.Name);
        Equal(10000m, gandalf.Bonus);
        
        CheckHuman(gandalf, 102, 10101);
        Equal("Manager Gandalf", gandalf.ToString());
        // item 416
        Equal("yellow", bilbo.Description);
        Equal("Bilbo", bilbo.Name);
        Equal(1000.0, bilbo.Salary);
        
        CheckHuman(bilbo, 55, 10102);
        Equal("Employee Bilbo", bilbo.ToString());
        // item 417
        Equal("green", fedor.Description);
        Equal("Fedor", fedor.Name);
        Equal(2000.0, fedor.Salary);
        
        CheckHuman(fedor, 57, 10103);
    }

    public static void NotEqual(object left, object right) {
        // item 353
        if (Object.Equals(left, right)) {
            // item 356
            throw new Exception("Objects are equal.");
        } else {
            
        }
    }

    public static void Put(string format, params object[] args) {
        // item 372
        System.Console.WriteLine(format, args);
    }

    public static void PutObj(object obj) {
        // item 378
        IBaseRecord rec = obj as IBaseRecord;
        // item 380
        if (rec == null) {
            // item 418
            if (obj == null) {
                // item 383
                Put("null");
            } else {
                // item 421
                Console.WriteLine("{0} {1}", obj.GetType().Name, obj);
            }
        } else {
            // item 379
            Console.WriteLine("{0} {1}", rec.GetType().Name, rec.Id);
        }
    }

    private static void CheckHuman(IHuman human, double weight, int dna) {
        // item 409
        Human human_ = (Human)human;
        Equal(weight, human_._weight);
        Equal(dna, human_._dna);
    }

    private static void SetWeight(ICreature creature, double weight) {
        // item 415
        ((Creature)creature)._weight = weight;
    }

    private static List<IBaseRecord> Sort<T>(IEnumerable<T> input) {
        // item 387
        List<IBaseRecord> records = (
        	from it in input
        	select (IBaseRecord)it).ToList();
        // item 390
        return (from rec in records
        	orderby rec.Id
        	select rec).ToList();
    }
}

