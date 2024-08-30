import './register.css'
import { Link } from 'react-router-dom';
const SignUp=()=>{
  return(
    <>
     <div class="container vh-100 d-flex align-items-center justify-content-center">
        <div class="card p-4 shadow-lg">
            <h2 class="text-center mb-4">Sign Up</h2>
            <form>
                <div class="mb-3">
                    <label for="username" class="form-label">Username</label>
                    <input type="text" class="form-control" id="username" placeholder="Enter your username"/>
                </div>
                <div class="mb-3">
                    <label for="email" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="email" placeholder="Enter your email"/>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <input type="password" class="form-control" id="password" placeholder="Enter your password"/>
                </div>
                <div class="d-grid">
                    <button type="submit" class="btn btn-primary btn-block"><Link  to='/SignIn'/>SignUp</button>
                 
                   
                    
                </div>
            </form>
            <div class="text-center mt-3">
                <p>Already have an account? <Link  to='/SignIn'><a href="#">Login here</a></Link></p>
                
            </div>
        </div>
    </div>

    
    </>
  )
}
export default SignUp;