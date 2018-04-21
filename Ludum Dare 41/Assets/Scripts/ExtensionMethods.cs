using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    //Method which looks at an object
    public static void LookAt2D(this Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //Method which shuffles a list
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static Color ChangeAlpha(this Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    //Method responsible for spawning bullets and managing them
    public static void Fire(float bulletSpeed, GameObject bullet, GameObject firingPoint)
    {
        //Variable which holds the instantiated bullet
        GameObject spawnedBullet;

        //Instantiate bullet and assign it to spawned bullet as a GameObject
        spawnedBullet = MonoBehaviour.Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation) as GameObject;

        spawnedBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, bulletSpeed), ForceMode2D.Impulse); //Add a relative force to the bullet
    }
}
