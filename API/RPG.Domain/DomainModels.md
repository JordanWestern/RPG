# Aggregates

## Player
```c#
class Player
{
    PlayerId Id;
    string Name;
    int Health;
    ItemId[] Items;

    Player Create();
    void AddItem(Item item);
    void UseItem(Item item);
    void MoveLocation(Location location);
    void TakeDamage(int damage)
}
```
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "player name",
    "health": 100,
    "items": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ]
}
```

## Location
```c#
class Location
{
    LocationId Id;
    string Name;
    string Description;
    EnemyId[] Enemies;
    ItemId[] Items;
    LocationId[] Connections;

    Location Create();
    void RemoveItem(Item item);
    void RemoveWeapon(Item item);
    void RemoveEnemy(Item item);
}
```
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "location name",
    "description": "location description",
    "enemies": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
    "items": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
    "connections": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
}
```

## Enemy
```c#
class Enemy
{
    EnemyId Id;
    string Name;
    string Description;
    int Health;
    ItemId[] Loot;

    Enemy Create();
    void TakeDamage(int damage);
}
```
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "enemy name",
    "description": "enemy description",
    "health": 100,
    "Loot": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ]
}
```

## Item
```c#
class Item
{
    ItemId Id;
    string Name;
    string Description;
    ItemType Type;

    Item Create();
    void Use();
}
```
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "item name",
    "description": "enemy description",
    "type": 0
}