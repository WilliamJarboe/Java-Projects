import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Entity here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Entity extends Actor
{
    int hp=4400;
    int fr = 0;
    int rmod = 0;
    boolean atk2 = true, atkh = true;
    GreenfootSound shot = new GreenfootSound("fire2.wav");
    /**
     * Act - do whatever the Entity wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(fr<=200){
            if(fr%10==0){
                setImage("ENTITY.png");
            }
            else if(fr%5==0){
                setImage("ENTITY_Ghost.png");
            }
        }
        if(fr==200){
            atkh = false;
        }
        
        if(fr%150==0){
            if(atk2){
                atk2=false;
            }
            else{
                atk2=true;
            }
        }
        
        
        if(!atk2&&fr%60==0&&atkh==false){
            int r = 0;
            while(r<360){
                getWorld().addObject(new Entity_Shot_1(r+rmod,3),getX()-319,getY()+8);
                r=r+10;
            }
            r = 0;
            while(r<360){
                getWorld().addObject(new Entity_Shot_1(r+rmod,3),getX()+319,getY()+8);
                r=r+10;
            }
            
            rmod++;
        }
        
        if(atk2&&fr%40==0&&atkh==false){
            shot.stop();
            try{
                shot.play();
                Char ene = (Char) getObjectsInRange(1800, Char.class).get(0);
                int x = ene.getX();
                int y = ene.getY();
                getWorld().addObject(new Entity_Shot_2(6,x,y),getX()-60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(5,x,y),getX()-60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(4,x,y),getX()-60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(3,x,y),getX()-60,getY()+70);
                
                getWorld().addObject(new Entity_Shot_2(6,x,y),getX()+60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(5,x,y),getX()+60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(4,x,y),getX()+60,getY()+70);
                getWorld().addObject(new Entity_Shot_2(3,x,y),getX()+60,getY()+70);
                
                getWorld().addObject(new Entity_Shot_2(6,x,y),getX()+185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(5,x,y),getX()+185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(4,x,y),getX()+185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(3,x,y),getX()+185,getY()+67);
                
                getWorld().addObject(new Entity_Shot_2(6,x,y),getX()-185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(5,x,y),getX()-185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(4,x,y),getX()-185,getY()+67);
                getWorld().addObject(new Entity_Shot_2(3,x,y),getX()-185,getY()+67);
            }
            catch(Exception E){}
        }
        
        
        
        if(hp<=0){
            getWorld().addObject(new ENTITY_D(1), getX(),getY());
            getWorld().addObject(new ENTITY_D(2), getX(),getY());
            getWorld().addObject(new ENTITY_D(3), getX(),getY());
            try{
                Env_Driver sparksy = (Env_Driver) getObjectsInRange(1800, Env_Driver.class).get(0);
                sparksy.win();
            }
            catch(Exception E){}
            getWorld().removeObject(this);
        }
        fr++;
    }
    
    public void damage(){
        hp = hp-1;
    }
}
