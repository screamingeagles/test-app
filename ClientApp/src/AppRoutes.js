import StudentAdd from "./components/Student/StudentAdd";
import StudentView from "./components/Student/StudentView";
import StudentUpdate from "./components/Student/StudentUpdate";
import StudentListing from "./components/Student/StudentListing";

import FamilyAdd from "./components/Family/FamilyAdd";
import FamilyView from "./components/Family/FamilyView";
import FamilyUpdate from "./components/Family/FamilyUpdate";
import FamilyListing from "./components/Family/FamilyListing";

const AppRoutes = [
  {
    index: true,
        path: '/students',
    element: <StudentListing />
  },
  {
    path: '/student/add',
    element: <StudentAdd />
  },
  {
    path: '/student/edit/:code',
    element: <StudentUpdate />
  },
  {
    path: '/student/view/:code',
    element: <StudentView />
  },
  {
    path: '/family/add/:code',
    element: <FamilyAdd />
  },
  {
    path: '/family/edit/:code',
    element: <FamilyUpdate />
  },
  {
    path: '/family/view/:code',
    element: <FamilyView />      
  },
  {
    path: '/family/:code',
    element: <FamilyListing />      
  }
];

export default AppRoutes;
