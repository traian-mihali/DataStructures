using DataStructures.NonLinearStructures;
using NUnit.Framework;
using System;

namespace DataStructures.UnitTests
{
    public class BinaryTreeTests
    {
        private BinaryTree _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new BinaryTree();
        }

        [Test]
        public void Find_WhenCalledOnEmptyTree_ReturnsFalse()
        {
            var result = _tree.Find(1);

            Assert.That(result, Is.False);
        }


        [Test]
        [TestCase(1, 1, true)]
        [TestCase(1, 2, false)]
        public void Find_WhenCalledOnTreeWithOneNode_ReturnsBoolean(int value, int searchedValue, bool expectedResult)
        {
            _tree.Insert(value);

            var result = _tree.Find(searchedValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(3, 1, 4, 3, true)]
        [TestCase(3, 1, 4, 1, true)]
        [TestCase(3, 1, 4, 4, true)]
        [TestCase(3, 1, 4, 2, false)]
        public void Find_WhenCalledOnTreeWithMoreThanOneNode_ReturnsBoolean(int value1, int value2, int value3, int searchedValue, bool expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Find(searchedValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Contains_WhenCalledOnEmptyTree_ReturnsFalse()
        {
            var result = _tree.Contains(1);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(1, 1, true)]
        [TestCase(1, 2, false)]
        public void Contains_WhenCalledOnTreeWithOneNode_ReturnsBoolean(int value, int searchedValue, bool expectedResult)
        {
            _tree.Insert(value);

            var result = _tree.Contains(searchedValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(3, 1, 4, 3, true)]
        [TestCase(3, 1, 4, 1, true)]
        [TestCase(3, 1, 4, 4, true)]
        [TestCase(3, 1, 4, 2, false)]
        public void Contains_WhenCalledOnTreeWithMoreThanOneNode_ReturnsBoolean(int value1, int value2, int value3, int searchedValue, bool expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Contains(searchedValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Height_WhenCalledOnEmptyTree_ReturnsMinusOne()
        {
            var result = _tree.Height();

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Height_WhenCalledOnTreeWithOneNode_ReturnsZero()
        {
            _tree.Insert(1);

            var result = _tree.Height();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(3, 1, 4, 1)]
        [TestCase(4, 2, 3, 2)]
        [TestCase(4, 6, 5, 2)]
        public void Height_WhenCalledOnTreeWithMoreThanOneNode_ReturnsTreeHeight(int value1, int value2, int value3, int expectedValue)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Height();

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Size_WhenCalledOnEmptyTree_ReturnsZero()
        {
            var result = _tree.Size();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Size_WhenCalledOnTreeWithOneNode_ReturnsOne()
        {
            _tree.Insert(1);
            var result = _tree.Size();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(3, 1, 4, 3)]
        [TestCase(4, 2, 3, 3)]
        [TestCase(4, 6, 5, 3)]
        public void Size_WhenCalledOnTreeWithMoreThanOneNode_ReturnsTotalNodes(int value1, int value2, int value3, int expectedValue)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Size();

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Min_WhenCalledOnEmptyTree_ThrowsInvalidOperationException()
        {
            Assert.That(() => _tree.Min(), Throws.TypeOf<InvalidOperationException>());

        }

        [Test]
        public void Min_WhenCalledOnTreeWithOneNode_ReturnsNodeValue()
        {
            _tree.Insert(1);

            var result = _tree.Min();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(3, 1, 4, 1)]
        [TestCase(4, 2, 3, 2)]
        [TestCase(4, 6, 5, 4)]
        public void Min_WhenCalledOnTreeWithMoreThanOneNode_ReturnsMinValue(int value1, int value2, int value3, int expectedValue)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Min();

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void MinFromBST_WhenCalledOnEmptyTree_ThrowsInvalidOperationException()
        {
            Assert.That(() => _tree.MinFromBST(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        [TestCase(3, 1, 4, 1)]
        [TestCase(4, 2, 3, 2)]
        [TestCase(4, 6, 5, 4)]
        public void MinFromBST_WhenCalled_ReturnsMinValue(int value1, int value2, int value3, int expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.MinFromBST();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Max_WhenCalledOnEmptyTree_ThrowsInvalidOperationException()
        {
            Assert.That(() => _tree.Max(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(3, 1, 4, 4)]
        [TestCase(4, 2, 3, 4)]
        [TestCase(4, 6, 5, 6)]
        public void Max_WhenCalled_ReturnsMaxValue(int value1, int value2, int value3, int expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.Max();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void MaxFromBST_WhenCalledOnEmptyTree_ThrowsInvalidOperationException()
        {
            Assert.That(() => _tree.MaxFromBST(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(3, 1, 4, 4)]
        [TestCase(4, 2, 3, 4)]
        [TestCase(4, 6, 5, 6)]
        public void MaxFromBST_WhenCalled_ReturnsMaxValue(int value1, int value2, int value3, int expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);

            var result = _tree.MaxFromBST();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Equals_WhenCalledWithNull_ReturnsFalse()
        {
            var result = _tree.Equals(null);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WhenCalledWithEmptyTree_ReturnsTrue()
        {
            var result = _tree.Equals(new BinaryTree());

            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_WhenCalledOnEmptyTree_ReturnsFalse()
        {
            var other = new BinaryTree();
            other.Insert(1);

            var result = _tree.Equals(other);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(3, 4, 1, true)]
        [TestCase(3, 1, 4, true)]
        [TestCase(3, 1, 2, false)]
        [TestCase(4, 1, 3, false)]
        public void Equals_WhenCalled_ReturnsBoolean(int value1, int value2, int value3, bool expectedValue)
        {
            _tree.Insert(3);
            _tree.Insert(1);
            _tree.Insert(4);

            var other = new BinaryTree();
            other.Insert(value1);
            other.Insert(value2);
            other.Insert(value3);

            var result = _tree.Equals(other);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void IsBinarySearchTree_WhenCalledOnEmptyTree_ReturnsTrue()
        {
            var result = _tree.IsBinarySearchTree();

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(5, 2, 3, 7, 4, 1, true)]
        [TestCase(5, 2, 3, 7, 4, 2, false)]
        public void IsBinarySearchTree_WhenCalled_ReturnsBoolean(int value1, int value2, int value3, int value4, int value5, int value6, bool expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);
            _tree.Insert(value6);

            var result = _tree.IsBinarySearchTree();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(0)]
        [TestCase(2)]
        public void GetNodesAtDistance_WhenCalledOnEmptyTree_ReturnsEmptyList(int distance)
        {
            var list = _tree.GetNodesAtDistance(distance);

            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetNodesAtDistance_WhenCalledWithDistanceZero_ReturnsListWithRoot()
        {
            _tree.Insert(3);
            _tree.Insert(1);
            _tree.Insert(4);
            _tree.Insert(2);

            var list = _tree.GetNodesAtDistance(0);

            Assert.That(list, Does.Contain(3));
        }

        [Test]
        [TestCase(3, 1, 4, 2, 1, new int[] { 1, 4 })]
        [TestCase(3, 1, 4, 2, 2, new int[] { 2 })]
        [TestCase(4, 2, 3, 1, 2, new int[] { 1, 3 })]
        public void GetNodesAtDistance_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int distance, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);

            var list = _tree.GetNodesAtDistance(distance);

            Assert.That(list, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void CountLeaves_WhenCalledOnEmptyTree_ReturnsZero()
        {
            var result = _tree.CountLeaves();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CountLeaves_WhenCalledOnTreeWithOneNode_ReturnsOne()
        {
            _tree.Insert(1);
            var result = _tree.CountLeaves();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(3, 1, 4, 2, 2)]
        [TestCase(4, 2, 3, 1, 2)]
        [TestCase(4, 3, 1, 2, 1)]
        public void CountLeaves_WhenCalledOnTreeWithMoreThanOneNode_ReturnsTotalLeaves(int value1, int value2, int value3, int value4, int expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);

            var result = _tree.CountLeaves();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AreSibling_WhenCalledOnEmptyTree_ReturnsFalse()
        {
            var result = _tree.AreSibling(1, 2);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase(4, 2, 3, 1, 1, 3, true)]
        [TestCase(3, 1, 4, 2, 1, 4, true)]
        [TestCase(3, 1, 4, 2, 2, 4, false)]
        public void AreSibling_WhenCalled_ReturnsBoolean(int value1, int value2, int value3, int value4, int compare1, int compare2, bool expectedResult)
        {

            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);

            var result = _tree.AreSibling(compare1, compare2);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetAncestors_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.GetAncestors(1);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetAncestors_WhenCalledOnTreeWithOneNode_ReturnsEmptyList()
        {
            _tree.Insert(1);
            var result = _tree.GetAncestors(1);

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 1, new int[] { 3 })]
        [TestCase(3, 1, 4, 2, 4, new int[] { 3 })]
        [TestCase(3, 1, 4, 2, 2, new int[] { 1, 3 })]
        [TestCase(4, 2, 3, 1, 3, new int[] { 2, 4 })]
        [TestCase(4, 2, 3, 1, 4, new int[] { })]
        [TestCase(4, 2, 3, 1, 5, new int[] { })]
        public void GetAncestors_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int target, int[] expectedResult)
        {

            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);

            var result = _tree.GetAncestors(target);

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void IsBalanced_WhenCalledOnEmptyTree_ReturnsTrue()
        {
            var result = _tree.IsBalanced();

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(3, 1, 4, 2, true)]
        [TestCase(3, 1, 4, 5, true)]
        [TestCase(4, 2, 3, 1, false)]
        public void IsBalanced_WhenCalled_ReturnsBoolean(int value1, int value2, int value3, int value4, bool expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);

            var result = _tree.IsBalanced();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TraverseLevelOrder_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.TraverseLevelOrder();

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 5, new int[] { 3, 1, 4, 2, 5 })]
        [TestCase(4, 2, 3, 5, 1, new int[] { 4, 2, 5, 1, 3 })]
        public void TraverseLevelOrder_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int value5, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);

            var result = _tree.TraverseLevelOrder();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TraverseBreadthFirst_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.TraverseBreadthFirst();

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 5, new int[] { 3, 1, 4, 2, 5 })]
        [TestCase(4, 2, 3, 5, 1, new int[] { 4, 2, 5, 1, 3 })]
        public void TraverseBreadthFirst_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int value5, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);

            var result = _tree.TraverseBreadthFirst();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TraversePreOrder_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.TraversePreOrder();

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 5, new int[] { 3, 1, 2, 4, 5 })]
        [TestCase(4, 2, 3, 5, 1, new int[] { 4, 2, 1, 3, 5 })]
        public void TraversePreOrder_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int value5, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);

            var result = _tree.TraversePreOrder();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TraverseInOrder_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.TraverseInOrder();

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(4, 2, 3, 5, 1, new int[] { 1, 2, 3, 4, 5 })]
        public void TraverseInOrder_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int value5, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);

            var result = _tree.TraverseInOrder();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TraversePostOrder_WhenCalledOnEmptyTree_ReturnsEmptyList()
        {
            var result = _tree.TraversePostOrder();

            Assert.That(result, Is.Empty);
        }

        [Test]
        [TestCase(3, 1, 4, 2, 5, new int[] { 2, 1, 5, 4, 3 })]
        [TestCase(4, 2, 3, 5, 1, new int[] { 1, 3, 2, 5, 4 })]
        public void TraversePostOrder_WhenCalled_ReturnsList(int value1, int value2, int value3, int value4, int value5, int[] expectedResult)
        {
            _tree.Insert(value1);
            _tree.Insert(value2);
            _tree.Insert(value3);
            _tree.Insert(value4);
            _tree.Insert(value5);

            var result = _tree.TraversePostOrder();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}