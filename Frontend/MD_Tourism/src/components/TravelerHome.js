import Navbar from './Navbar';
import Hero from './Hero';
import Services from './Services';
import Recommend from './Recommend';
import Testimonials from './Testimonials';
import Footer from './Footer';
import ScrollToTop from './ScrollToTop';

export default function TravelerHome() {
    return (
        <div>
            <ScrollToTop />
            <Navbar />
            <Hero />
            <Recommend />
            <Testimonials />
            <Footer />
        </div>
    );
}