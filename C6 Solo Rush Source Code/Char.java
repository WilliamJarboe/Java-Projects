import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)
/**
 * Write a description of class Char here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Char extends Actor
{
    private int turnstasis = 0;
    private boolean first = true;
    private int mX = 0, mY = 0, button, vec = 0, shi = 0;
    private boolean lmb = false, inGame = false;
    private int score = 0;
    private int fr = 0;
    /**
     * Act - do whatever the Char wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act()
    {
        fr++;
        if(first){turnTowards(getX(),getY()-1);first=false;}
        checkMouse();
        motion();
        MouseInfo mouse = Greenfoot.getMouseInfo();
        if(mouse!=null){
            button = mouse.getButton();
            if(button == 1)
            {
                lmb = true;
            }
            else if(!((Greenfoot.mousePressed(getWorld()))||(Greenfoot.mousePressed(Title_Screen.class)))){
                lmb =false;
            }
        }
        if(lmb){
            if(vec==0&&fr%2==0){
                CharShot charShotA = new CharShot(getRotation(),15,false);
                getWorld().addObject(charShotA, getX(), getY());
            }
            
            if(vec>0){
                CharShot charShotA = new CharShot(getRotation(),20,true,2);
                getWorld().addObject(charShotA, getX(), getY());
                
                CharShot charShotB = new CharShot(getRotation()-20,20,true,1);
                getWorld().addObject(charShotB, getX(), getY());
                CharShot charShotC = new CharShot(getRotation()+20,20,true,1);
                getWorld().addObject(charShotC, getX(), getY());
                vec--;
            }
        }
        
        getWorld().showText("EX Ammo: "+vec+"",80,getWorld().getHeight()-15); //this is the biggest gun in the game, other than entity's.
        if(inGame){
            score++;
        }
    }
    
    public void checkMouse()
    {
        MouseInfo mouse = Greenfoot.getMouseInfo();
        if(mouse!=null){
            button = mouse.getButton();
            mX=mouse.getX();
            mY=mouse.getY();
            turnTowards(mX, mY);
        }
    }
    
    public void motion(){
        if(Greenfoot.isKeyDown("d")){
            setLocation(getX()+4,getY());
        }
        if(Greenfoot.isKeyDown("a")){
            setLocation(getX()-4,getY());
        }
        if(Greenfoot.isKeyDown("w")&&getY()>=100){
            setLocation(getX(),getY()-4);
        }
        if(Greenfoot.isKeyDown("s")){
            setLocation(getX(),getY()+4);
        }
    }
    
    public void shotMod(){
        vec+=180;//Your copilot (and wife, if you wanna go there) charges up the bigger of the two weapons on the ship using the powerup yu just obtained and gives you a smirk.
    }
    public void beginGame(){
        score = 0;
        inGame = true;
    }
    
    public int getScore(){
        return score;
    }
}
