- Each feature was tested right after coding, until that feature was whit out any bugs
- Becouse of scriptable object usage, i managed to sort every item accordingly by:
	is an item equipable or not
	is an item consumable or not
	is an item used upon picking up
	is an item used to equip on players head
	is an item used to equip on players torso
	is an item used to equip on players left hand(weapon)
	is an item used to equip on players right hand (shield)
- each item grants the player a boost of:
	strenght
	dexterity
	agility
	intelligence
- Player script: controls player movement and animation, controls player stats
- GameManager script: keeps track of the items entered the inventory, and controls some of the constant variables
- UiManager script: controls the opening / closing of panels, keep track is an item equipped on a player, controls the drop function for items
- UnEquip script: unequip the items from the equip panel and sets them into the inventory panel if the inventory panel is not full, also it can exchange the item in the
  equip panel with an item that was click inside the inventory panel
- strings script: contain some strings as variables
- MoData script: show the Data of each item in inventory upon hovering
- Items script : controls what item collied with the player, and equips the equippable item to the player if that items is not yet equipped
- Inventory icon script: holds all the info relevant for the picked up item inside the icon in inventory panel
- InventoryControl script: sets the rows and cell number of the grid, fills the grid upon starting the game with empty space
- EquipPanel Script: controls the equip function from the inventory panel to the equip panel, every time an item gets equipped, the player gets the new value for: Strength,
  Dexterity, Agility, Intelligence
- ItemsDataBaseSO script: holds all of the created scriptable objects
- itemSO script: holds all the info of an item 

Shortcuts:
E - open close Equip Panel
I - Open Close Inventory Panel
C - Open CLose Player Stats Panel

Right click on Equipped item insde Equip Panel - Unequip it

Combo Key for Dropping Items from Inventory  - P + LEFT CLICK

Consuming Consumable Item from Inventory - MIDDLE CLICK

ESCAPE BUTTON - return the item to the inventory panel while the item is "in the air"

THE MAIL: exordium.sandbox1@gmail.com WAS ADDED TO THE REPOSITORY ON GITHUB FOR MY SOLUTION