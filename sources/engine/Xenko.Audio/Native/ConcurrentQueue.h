template <typename T>
class ConcurrentQueue
{
public:
	ConcurrentQueue() :
		_capacity(0),
		_array(nullptr),
		_size(0),
		_head(0),
		_tail(0)
	{
	}
	~ConcurrentQueue()
	{
		if (_array != nullptr)
		{
			delete _array;
			_array = nullptr;
		}
	}

	void SetCapacity(int capacity)
	{
		if (_array != nullptr)
		{
			delete _array;
		}
		_capacity = capacity;
		_array = new T[capacity];
	}

	void Enqueue(const T& item)
	{
		_array[_tail] = item;
		if (++_tail == _capacity)
		{
			_tail = 0;
		}
		__sync_add_and_fetch(&_size, 1);
	}

	bool TryDequeue(T& item)
	{
		if (_size == 0)
		{
			item = T();
			return false;
		}
		item = _array[_head];
		if (++_head == _capacity)
		{
			_head = 0;
		}
		__sync_sub_and_fetch(&_size, 1);
		return true;
	}

	T First()
	{
		return _array[0];
	}

	void Clear()
	{
		_size = 0;
		_head = 0;
		_tail = 0;
	}

private:
	int _capacity;
	T* _array;
	volatile int _size;
	int _head;
	int _tail;
};
