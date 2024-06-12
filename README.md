# farm


## Setup Environment
```
$ docker run -it --rm -p 9090:9090 kyehuang/pros_crane:latest /bin/bash
```

## Docker Shell
```
$ r
$ tmux              // open two terminal 
$ ros2 launch rosbridge_server rosbridge_websocket_launch.xml
$ ros2 run pros_crane_py crane
```

## Keyboard Controls
### Crane Movement
- Press 'w' : Move the crane up
- Press 's' : Move the crane down
- Press 'a' : Move the crane left
- Press 'd' : Move the crane right
- Press 'z' : Move the crane along the z-axis in the positive direction
- Press 'c' : Move the crane along the z-axis in the negative direction

### arm controll
- Press 'i' : Lift the arm up
- Press 'k' : Lower the arm down
- Press 'j' : Turn the arm left
- Press 'l' : Turn the arm right
- Press 'u' : Rotate the arm's fourth joint to the left
- Press 'o' : Rotate the arm's fourth joint to the right
