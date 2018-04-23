namespace AssociatedCollectionFilter {
    using System;
    using DevExpress.Xpo;
    
    
	[Persistent("Customers")]
	public class Customer : XPLiteObject {
        public Customer(Session session) : base(session) { }
		[Key]
		public string CustomerID;
		public string CompanyName;
		public string ContactTitle;

		[Association("CustomerOrders", typeof(Order))]
		public XPCollection Orders {
			get {
				return GetCollection("Orders");
			}
		}
	}

	[Persistent("Orders")]
	public class Order : XPLiteObject {
        public Order(Session session) : base(session) { }

		[Key]
		public int OrderID;
		
		[Persistent("CustomerID"), Association("CustomerOrders")]
		public Customer Customer;

		[Persistent("EmployeeID"), Association("EmployeeOrders")]
		public Employee Employee;

        public DateTime OrderDate;
        public decimal Freight;
	}

	[Persistent("Employees")]
	public class Employee : XPLiteObject {
        public Employee(Session session) : base(session) { }
		[Key]
		public int EmployeeID;
		public string FirstName;
		public string LastName;

		[Association("EmployeeOrders", typeof(Order))]
		public XPCollection Orders {
			get {
				return GetCollection("Orders");
			}
		}
	}
}
