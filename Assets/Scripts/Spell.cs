public class Spell {

    private string name;
    private float damage;
    private float velocity;
    private string description;
    private bool[,] shape;

    public string getName() {
        return this.name;
	}

    public float getDamage() {
        return this.damage;
    }

	public float getVelocity() {
        return this.velocity;
	}

    public string getDescription() {
        return this.description;
    }

    public bool[,] getShape() {
        return this.shape;
    }

    public Spell(string name, float damage, float velocity, string description, bool[,] shape) {
        this.name = name;
        this.damage = damage;
        this.velocity = velocity;
        this.description = description;
        this.shape = shape;
    }
}
