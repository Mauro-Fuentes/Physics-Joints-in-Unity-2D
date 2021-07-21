﻿/*
 * Copyright (c) 2020 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class CattoController : MonoBehaviour
{
    public float cattoJumpForce;
    public float cattoSpeed;

    private Rigidbody2D cattoRigidbody2D;
    private GroundChecker groundChecker;
    private SpriteRenderer cattoSpriteRenderer;

    public Vector2 vectorMovement;

    public bool cattoIsFacingRight = true; // by default Catto faces right

    public void Start()
    {
        cattoRigidbody2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        cattoSpriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    public void FixedUpdate()
    {
        PlayerMovement(vectorMovement);  
    }

    private void PlayerMovement(Vector2 movement)
    {
        cattoRigidbody2D.velocity = new Vector2(movement.x * cattoSpeed, cattoRigidbody2D.velocity.y); // * Time.deltaTime
    }

    private void OnJump()
    {
        if (groundChecker.IsCattoGrounded())
        {
            cattoRigidbody2D.AddForce(new Vector2(0f, cattoJumpForce));
        }
    }

    private void OnMove(InputValue input)
    {
        vectorMovement = input.Get<Vector2>();

        SetCattoDirection(vectorMovement.x);

        ShouldCattoBeFlipped(vectorMovement);
    }

    private void SetCattoDirection(float movement)
    {
        if(movement > 0.01f)
        {
            cattoIsFacingRight = true;

        }
        if(movement < 0.01f)
        {
            cattoIsFacingRight = false;
        }
    }

    private void ShouldCattoBeFlipped(Vector2 movement)
    {
        // if input is 0 return;

        // if catoo is facing a different direction from that of the input... yes
        if (movement.x > 0f && !cattoIsFacingRight)
        {
            FlipCatto();
        }

        if(movement.x < 0f && cattoIsFacingRight)
        {
            FlipCatto();
        }
    }

    private void FlipCatto() // Vector2 movement
    {
        cattoIsFacingRight = !cattoIsFacingRight;

        //Vector3 cattoScale = transform.localScale;
        //cattoScale.x *= -1;
        //transform.localScale = cattoScale;

        cattoSpriteRenderer.flipX = true;
    }
}
