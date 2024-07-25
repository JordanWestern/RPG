# Aggregates

## Player
```c#
class Player
{
    PlayerId Id;
    string Name;
    int Health;
    ItemId[] Items;
    GameLogId[] Logs;

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
    void RemoveEnemy(Enemy item);
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
    State State;

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
    ],
    "state": 0
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

    Item Create(string name, string description, ItemType type);
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
```

## Game log
```c#
class GameLog
{
    GameLogId Id;
    PlayerId PlayerId;
    DateTime Created;
    string Message;

    GameLog Create(PlayerId playerId, string message);
}
```
```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "playerId": "00000000-0000-0000-0000-000000000000",
    "created": "25/07/2024 20:14:08",
    "logMessage": "log message"
}
```