using CustomList;


namespace CustomListTest
{
    [TestClass]
    public class CustomListTest1
    {
        [TestMethod]
        //test 1
        public void Add_Items_CountCapacity()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();

            //Act
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            //Assert
            Assert.AreEqual(5, list.Count);
            //the count should be 2 after adding 3 items.

        }
        //test 2
        public void FirstItem_Added_IsFound_AtIndexZero()
        {
            CustomList<string> list = new CustomList<string>();
            list.Add("first");
            list.Add("second");
            list.Add("third");

            Assert.AreEqual("first", list[0]);
        }
        //test 3
        public void SecondItem_Added_IsFound_AtIndexOne()
        {
            CustomList<string> customList = new CustomList<string>();
            customList.Add("first");
            customList.Add("second");
            customList.Add("third");

            Assert.AreEqual("second", customList[1]);
        }
        //test 4
        public void Capacity_Increases_WhenExceeded()
        {
            //Arrange

            CustomList<int> customList = new CustomList<int>();
            //Act
            for (int i = 0; i< 10; i++)
            {
                customList.Add(i);
            }
            Assert.IsTrue(customList.Capacity>4);
        }
        //test 5
        public void AfterCapacityIncreases_AtLeastOneOriginalItem_Persists_AtOldIndex()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            for (int i = 0; i < 5; i++)
            {
                customList.Add(i);
            }
            int itemAtIndex3 = customList[3];
            for (int i = 5; i < 10; i++)
            {
                customList.Add(i);
            }
            int persistedItem = customList[3];

            //Assert
            Assert.AreEqual(itemAtIndex3, persistedItem);

            //one of the original items should persist at index 0
           
        }
        //Test 1 Remove
        public void Remove_Items_DecrementsCountCapacity()
        {
            //Arrange
            CustomList<int> list = new CustomList<int> { 10,20,30};
            


            //Act
            list.Remove(20);



            //Assert

            Assert.AreEqual(2, list.Count);
            //the count should be 2 after adding 3 items.

        }
        // Test 2 Remove
        public void Removed_ReturnsTrue_OnSuccessfulRemoval()
        {
            //Arrange
            CustomList<string> customList = new CustomList<string>();
            customList.Add("item");
            //Act
            bool removed = customList.Remove("item");

            Assert.IsTrue(removed);
        }
        // Test 3 Remove
        public void CountDoesNotDecrement_OnUnSuccessfulRemoval()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);

            //Act
            bool removed= customList.Remove(3);

            //Assert
            Assert.IsFalse(removed);
            Assert.AreEqual(2, customList.Count);
        }
        // Test 4 Remove
        public void Capacity_Decreases_WhenItemRemoved()
        {
            //Arrange
            CustomList<char> customList = new CustomList<char>('a','b','c');
            
           
            //Act
            customList.Remove('b');


            //Assert
            Assert.AreEqual('c', customList[1]);
        }
        // Test 5 Remove
        public void RemoveFirstDuplicateItem()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int> { 1, 2, 3, 2, 4 };
            
            //Act
            customList.Remove(2);

            //Assert
           
            Assert.AreEqual(3, customList[1]);
        }
        public void ToString_ReturnsExpectedResult_ForListOfStrings()
        {
            //Arrange
            CustomList<string> list = new CustomList<string> { "apple", "orange", "banana" };
          
            //Act
            

            //Assert
            
            Assert.AreEqual("apple,orange,banana",list.ToString());
        }
        public void ToString_ReturnsExpectedResult_ForListOfInt()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
           
            //Act
            string result = customList.ToString();

            //Assert
            
            Assert.AreEqual("1 2", result);

        }
        public void ToString_ReturnEmptyString_ForEmptyList()
        {
            //Arrange
            CustomList<double> customList = new CustomList<double>();

            //Act
            string result = customList.ToString();

            //Assert
            
            Assert.AreEqual("", result);
        }

        public void PlusOperator_ReturnsCombinedList_FirstListLonger()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int> { 1, 2, 3 };

            CustomList<int> list2 = new CustomList<int> { 4, 5 };



            //Act
            CustomList<int> result = list1 + list2;



            //Assert

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(4, result[3]);
            Assert.AreEqual(5, result[4]);
        }
        public void PlusOperator_ReturnsCombinedList_SecondListLonger()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int> { 1, 2 };
            CustomList<int> list2 = new CustomList<int> { 3, 4, 5 };

            //Act
            CustomList<int> result = list1 + list2;
            //Assert

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(4, result[3]);
            Assert.AreEqual(5, result[4]);
        }
        public void PlusOperator_ReturnsUnchangedResult_OneListEmpty()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>(1, 2, 3);
            CustomList<int> list2 = new CustomList<int>();


            //Act
            CustomList<int> combinedList = list1 + list2;
            //Assert
            string expected = "1 2 3";
            Assert.AreEqual(expected, combinedList.ToString());

        }
        public class CustomList<T> : List<T>
        {
            public CustomList() : base()
            {

            }
            public CustomList(params T[] items) : base(items)
            {

            }
            public new IEnumerator<T> GetEnumerator()
            {
                return base.GetEnumerator();
            }


            public CustomList(int capacity) : base(capacity)
            {

            }
            public CustomList(IEnumerable<T> collection) : base(collection)
            {

            }
        }






    }
}