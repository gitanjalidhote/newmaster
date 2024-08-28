import './Login.css'
import { Link } from 'react-router-dom';
const LogIn=()=>{
  return(
    <>
      <div class="container vh-100 d-flex align-items-center justify-content-center">
        <div class="card p-4 shadow-lg">
            <h2 class="text-center mb-4">Log In</h2>
            <form>
              
                <div class="mb-3">
                    <label for="email" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="email" placeholder="name@example.com"/>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <input type="password" class="form-control" id="password" placeholder="Enter your password"/>
                </div>
                <div class="d-grid">
                    <button type="submit" class="btn btn-primary btn-block" link to >Login</button>
                    <p> <Link to='/Homepage'><a href="#">Homepage</a></Link></p>
                    
                </div>
            </form>
            <div class="text-center mt-3">
                <p>If you dont have account <Link to='/'><a href="#">SignUp here</a></Link></p>
            </div>
        </div>
    </div>
    </>
  )
}

export default LogIn;