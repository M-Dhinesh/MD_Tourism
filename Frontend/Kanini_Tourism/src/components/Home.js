// import Navbar from './Navbar';
import Hero from './Hero';
import Services from './Services';
import Recommend from './Recommend';
import Testimonials from './Testimonials';
import Footer from './Footer';
import ScrollToTop from './ScrollToTop';
import AfterLoginNavbar from './AfterLoginNavbar';

export default function Home() {
    return (
        <div>
            <ScrollToTop />
            <AfterLoginNavbar />
            <Hero />
            <Services />
            <Recommend />
            <Testimonials />
            <Footer />
        </div>
    );
}