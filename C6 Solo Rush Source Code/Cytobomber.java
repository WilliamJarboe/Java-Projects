import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Cytobomber here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Cytobomber extends Actor
{
    double fr = 0;
    
    int bx, x=0, yex = 100;
    boolean first = true, sin, onEdge = false;
    public Cytobomber(){
        yex = (int)(Math.random()*300)+100;
    }
    /**
     * Act - do whatever the Cytobomber wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            bx = getX();
            if(Math.random()>.5){
                sin = true;
            }
            else{
                sin = false;
            }
            first=false;
        }
        fr = fr+.07;
        if(sin){
            setLocation((int)(Math.sin(fr)*150)+bx,(int)(fr*20));
        }
        else{
            setLocation((int)(Math.cos(fr)*150)+bx,(int)(fr*20));
        }
        EnemShot EnemShotA;
        turn(8);
        if(getX()<=4||getX()>=getWorld().getWidth()-4){
            yex = getY();
        }
        if(getY()>yex){
            try{
                Char ene = (Char) getObjectsInRange(1800, Char.class).get(0);
                int x = ene.getX();
                int y = ene.getY();
                getWorld().addObject(new Entity_Shot_2(5,x,y),getX(),getY());
                getWorld().removeObject(this);
            }catch(Exception e){getWorld().removeObject(this);}
        }
    }    
}
