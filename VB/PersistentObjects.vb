Imports Microsoft.VisualBasic
	Imports System
	Imports DevExpress.Xpo
Namespace AssociatedCollectionFilter


	<Persistent("Customers")> _
	Public Class Customer
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Key> _
		Public CustomerID As String
		Public CompanyName As String
		Public ContactTitle As String

		<Association("CustomerOrders", GetType(Order))> _
		Public ReadOnly Property Orders() As XPCollection
			Get
				Return GetCollection("Orders")
			End Get
		End Property
	End Class

	<Persistent("Orders")> _
	Public Class Order
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key> _
		Public OrderID As Integer

		<Persistent("CustomerID"), Association("CustomerOrders")> _
		Public Customer As Customer

		<Persistent("EmployeeID"), Association("EmployeeOrders")> _
		Public Employee As Employee

		Public OrderDate As DateTime
		Public Freight As Decimal
	End Class

	<Persistent("Employees")> _
	Public Class Employee
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Key> _
		Public EmployeeID As Integer
		Public FirstName As String
		Public LastName As String

		<Association("EmployeeOrders", GetType(Order))> _
		Public ReadOnly Property Orders() As XPCollection
			Get
				Return GetCollection("Orders")
			End Get
		End Property
	End Class
End Namespace
