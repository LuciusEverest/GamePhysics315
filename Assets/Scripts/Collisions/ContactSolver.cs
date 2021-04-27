using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContactSolver
{
    public static void Resolve(List<Contact> contacts)
    {
        foreach(Contact contact in contacts)
        {
            // Separation
            float totalInverseMass = contact.bodyA.inverseMass + contact.bodyB.inverseMass;
            Vector2 serperation = contact.normal * contact.depth / totalInverseMass;
            contact.bodyA.position = contact.bodyA.position + serperation * contact.bodyA.inverseMass;
            contact.bodyB.position = contact.bodyB.position - serperation * contact.bodyB.inverseMass;

            // Collision Impulse
            Vector2 relativeVelocity = contact.bodyA.velocity - contact.bodyB.velocity;
            float normalVelocity = Vector2.Dot(relativeVelocity, contact.normal);

            if (normalVelocity > 0) continue;

            float restitution = (contact.bodyA.restitution + contact.bodyB.restitution) * 0.5f;

            float impulseMagnitude = -(1.0f + restitution) * normalVelocity / totalInverseMass;

            Vector2 impulse = contact.normal * impulseMagnitude;
            contact.bodyA.AddForce(contact.bodyA.velocity + (impulse * contact.bodyA.inverseMass), Body.eForceMode.Velocity);
            contact.bodyB.AddForce(contact.bodyB.velocity - (impulse * contact.bodyB.inverseMass), Body.eForceMode.Velocity);
        }
    }
}
