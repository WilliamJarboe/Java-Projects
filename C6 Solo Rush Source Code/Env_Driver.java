import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Env_Driver here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Env_Driver extends Actor
{
    boolean first = true, second = true, counting = false, sdnm = false;
    int fr = 0, s = 3, vol = 100;
    GreenfootSound enigmata = new GreenfootSound("C6 Enigma music.mp3");
    GreenfootSound fboss = new GreenfootSound("unexpectedboss.mp3");
    /**
     * Act - do whatever the BGM_Driver wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            //Greenfoot.playSound("C6 Enigma music.mp3");
            enigmata.play();
            Greenfoot.playSound("WaveStart.wav");
            first = false;
        }
        
        if(isTouching(GameOver_Screen.class)){
            enigmata.stop();
            fboss.stop();
        }
        
        try{
            Entity e = (Entity)getObjectsInRange(1000, Entity.class).get(0);
            if(e!=null){
                s = 9;
                playBossMusic();
            }
        }
        catch(Exception e){}
        
        if(counting){
            fr++;
        }
        
        if(fr%400==0){
            Background_Star shining = new Background_Star(((int)(Math.random()*s))+1);
            getWorld().addObject(shining,((int)(Math.random()*getWorld().getWidth())),0);
        }
        if(counting && fboss.isPlaying()){
            fboss.stop();
        }
        if(fr==200){
            getWorld().addObject(new Credits_Win(),getWorld().getWidth()/2,getWorld().getHeight()/2);
            getWorld().removeObject(this);
        }
        
        if(sdnm&&fr%10==0){
            enigmata.setVolume(vol);
            vol = vol-1;
            if(vol == 80){
                Greenfoot.playSound("WaveStart.wav");
                getWorld().addObject(new Warning_Bar(),getWorld().getWidth()/2,300);
            }
            if(vol<=4){
                enigmata.stop();
                sdnm = false;
            }
        }
        
    }  
    
    public void playBossMusic(){
        if(second==true){
            second = false;
            fboss.play();
            sdnm = true;
        }
        
    }
    
    public void win(){
        Greenfoot.playSound("explosion.wav");
        counting = true;
        fboss.stop();
    }
}