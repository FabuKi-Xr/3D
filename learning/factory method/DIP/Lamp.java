package DIP;

public class Lamp implements switchableDevice {
    Lamp(){
        
    }
    @Override
    public void turnOff() {
        System.out.println("Lamp turn off");
        
    }

    @Override
    public void turnOn() {
        System.out.println("Lamp turn On");
        
    }
    
}
