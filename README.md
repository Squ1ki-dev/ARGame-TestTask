# ARGame-TestTask
 
<br>Game items are divided by configs (ScriptbleObject). <br>Configs in Resources/Configs<br/>
<br>ObjectType CO is a variant of an object that can use a specific prefab, ObjectListCO is a list of objects that will be used in the project<br/>
<br>ObjectPooling is used for optimization, it is also used for sounds.<br/>
<br>Also, the FPS is limited to 30, to reduce memory and battery consumption.<br/>
<br>The inventory is also divided into CO for convenience. Default, Basic, and Modified are variations of items for the UI inventory, the location of inventory items can also be configured using the InventoryDisplay config<br/>
<br>The prefabs of objects that can be used in the game are attached to the Item script, which receives the config (Default, Basic, Modified)<br/>
<br>The prefab also has a script with animation, it is convenient to configure the values ​​​​through the editor<br/>
<br>In order to spawn something from the Pool, you need to enter: ObjectPool.SpawnObject (obj, Vector3, Quaternion);<br/>
<br>In order to remove: ObjectPool.ReturnToPool (obj);<br/>
<br>In order to play a sound through the Pool, you need to get SoundData and write SoundManager.Instance.CreateSoundBuilder().WithRandomPitch().WithPosition(hit.collider.transform.position).Play(soundData);<br/>

<br>!!!!I HAVE A PROBLEM WITH RELOADING THE SCENE, THE RESET SESSION DIDN'T HELP ME, AND I DIDN'T FIND AN ANSWER SO I DIDN'T MAKE IT PROPERLY!!!!!<br/>
