# Monobehaviour based Singleton 
These scripts lets any monobehaviour classes to be single just by inheriting from the singleton class.
These classes are modified versions of Microsoft Holotookit's singleton implementation

### Usage
1. **Singleton** : To make any monobehaviour class singleton, just inherit it from `Singleton<T>` class. This will make sure there is only one instance of the class available. This does not support inheriting child classes from the base singleton class.

2. **Inheritable Singleton**. The `InheritableSingleton` class is same as the `Singleton` class except it allows multiple sibling classes to be present from the base singleton class.
