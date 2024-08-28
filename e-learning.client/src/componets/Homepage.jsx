
import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Router } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';


// import './componets/Homepage.css'
const Homepage = () => {
  return (
    <>
      <div>

        <div>
          <nav class="navbar navbar-expand-lg bg-body-tertiary">
            <div class="container-fluid">
              <a class="navbar-brand" href="#">E-Learning-Quiz-System</a>
              <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                  <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href="#">Home</a>
                  </li>


                  <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                      Who i am
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="#">Student</a></li>
                      <li><a class="dropdown-item" href="#">Instructor</a></li>

                    </ul>
                  </li>
                  <li class="nav-item dropdown">
                    <a
                      class="nav-link dropdown-toggle"
                      href="#"
                      role="button"
                      data-bs-toggle="dropdown"
                      aria-expanded="false"
                    >
                      Subject
                    </a>
                    <ul class="dropdown-menu">
                      <li><a class="dropdown-item" href="#">Maths</a></li>
                      <li><hr class="dropdown-divider" /></li>
                      <li><a class="dropdown-item" href="#">GK</a></li>
                  

                    </ul>
                  </li>



                </ul>
                <form class="d-flex" role="search">

                  <button type="submit" class="btn btn-primary btn-block" link to >Login</button> &nbsp;

                  <button type="submit" class="btn btn-primary btn-block">SignUp</button>

                </form>
              </div>
            </div>
          </nav>

        </div>



        <div>
<img src="" style={{backgroundImage:`URL("https://png.pngtree.com/thumb_back/fh260/background/20210929/pngtree-abstract-background-glassmorphism-pastel-color-image_908574.png"))`,  minHeight:"100vh",backgroundSize:"cover",backgroundRepeat:"no-repeat"}}  alt="" />
        </div>



      </div>

    </>




  );
}
export default Homepage;