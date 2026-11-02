using System.Runtime.CompilerServices;

namespace PracticaU1Act2;

/// <summary>
/// Read-only information about a node. It lets the program display the structure
/// without handing out the real node (which could be modified from outside).
/// </summary>
public readonly record struct NodeInfo(int Position, int Value, int Id, int? NextId);

/// <summary>
/// Program 2: singly linked list using dynamic memory.
/// One node is allocated per element, exactly when it is needed; nothing is ever copied.
/// </summary>
public class DynamicList
{
    /// <summary>
    /// Private node: each instance is created with "new" and lives on the Heap.
    /// Only the list can create nodes or change their links (encapsulation).
    /// </summary>
    private sealed class Node
    {
        public int Value { get; }
        public Node? Next { get; set; }

        public Node(int value) => Value = value;
    }

    private Node? _head;
    private Node? _tail;           // allows appending at the end in O(1)

    public int Count { get; private set; }

    /// <summary>Creates a new node on the Heap and links it at the end: O(1).</summary>
    public void Add(int value)
    {
        var newNode = new Node(value);
        if (_head is null)
            _head = _tail = newNode;
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }
        Count++;
    }

    /// <summary>There is no index: the links must be followed, O(n).</summary>
    public int Get(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException(ErrorMessages.OutOfRange(index, Count));

        Node current = _head!;
        for (int i = 0; i < index; i++)
            current = current.Next!;
        return current.Value;
    }

    /// <summary>
    /// Describes the first nodes by following the references. The Id is the identity
    /// code of the object in .NET: it tells instances apart, but it is not a real address.
    /// </summary>
    public IEnumerable<NodeInfo> DescribeNodes(int max)
    {
        Node? current = _head;
        int position = 0;
        while (current is not null && position < max)
        {
            int? nextId = current.Next is null ? null : RuntimeHelpers.GetHashCode(current.Next);
            yield return new NodeInfo(position, current.Value, RuntimeHelpers.GetHashCode(current), nextId);
            current = current.Next;
            position++;
        }
    }

    /// <summary>Removes the first node; it is left without references and the GC frees it.</summary>
    public bool RemoveFirst()
    {
        if (_head is null) return false;
        _head = _head.Next;
        if (_head is null) _tail = null;
        Count--;
        return true;
    }
}
