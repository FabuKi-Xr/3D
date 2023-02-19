public class OPS implements C3Ops,c2Ops {
    OPS(){
        super();
    }

    @Override
    public void op3() {
        System.out.println("hello world");
    
    }
    @Override
    public void op2() {
        System.out.println("it's C2ops");
    }
}
