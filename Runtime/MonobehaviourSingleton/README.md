
# Monobehaviour based Singleton 
These scripts lets any monobehaviour classes to be single just by inheriting from the singleton class.
These classes are modified versions of Microsoft Holotookit's singleton implementation

### Usage
1. **Singleton** : To make any monobehaviour class singleton, just inherit it from `Singleton<T>` class. This will make sure there is only one instance of the class available. This does not support inheriting child classes from the base singleton class. The singleton instance can be obtained by `SingletonClass.Instance` property.

```C#
using AVR.Utils
public class GameManager: Singleton<GameManager>
{
	void Start()
	{
	}
	void Update()
	{
	}
}
```

2. **Inheritable Singleton**. The `InheritableSingleton` class is same as the `Singleton` class except it allows multiple sibling classes to be present from the base singleton class. The singleton instance can be obtained by `SingletonClass.Instance` property.
```C#
using AVR.Utils
public abstract class Manager: InheritableSingleton<GameManager>
{
	
}

/// An iherited memeber of Manager class which is a singleton
public class GameManager : Manager
{
	void Start()
	{
	}
	void Update()
	{
	}
}
/// Anoher inherited memeber of Manager class which is a singleton
public class AudioManager: Manager
{
	void Start()
	{
	}
	void Update()
	{
	}
}
```
